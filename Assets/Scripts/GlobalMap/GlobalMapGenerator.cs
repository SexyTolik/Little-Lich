using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class GlobalMapGenerator : MonoBehaviour
{/// <summary>
/// 0-деревня 1-крепость 2-замок
/// </summary>
    [Header("Обязательно установить значение в эдиторе")]
    public List<GameObject> Locations = new List<GameObject>(2); // здесь хранятся префабы локаций, для того чтобы не усложять код следует размещать префабы в порядке 0-деревня,1-крепость,2-замок
    public int VillageCount = 5;
    public int TargetLocationsCount = 5;
    public Tilemap tilemap;


    private TileBase[] allTiles;
    private BoundsInt mapBounds;
    private List<LocParams> LocationsInstanses = new List<LocParams>();
    private GlobalMapSaver mapSaver;
    private List<string> BattleMapNames = new List<string>();
    void Awake()
    {
        mapSaver = GlobalMapSaver.instance;
        mapBounds = tilemap.cellBounds;
        allTiles = tilemap.GetTilesBlock(mapBounds);

        Object[] locs = Resources.LoadAll("Locations");
        foreach (Object loc in locs)
        {
            BattleMapNames.Add(loc.name);
        }
        GenerateGrid();
    }

    private void GenerateGrid()
    {
        if (mapSaver.CheckCompanyProgress())
        {
            if (mapSaver.loadMap())
            {
                
                foreach(string loc in mapSaver.save.LocationsData)
                {
                    LocParams lpar = JsonUtility.FromJson<LocParams>(loc);
                   GameObject location = Instantiate(Locations[0], lpar.LocPos, Quaternion.identity);
                   location.GetComponent<LocationController>().Params.locationComplite = lpar.locationComplite;
                   location.GetComponent<LocationController>().locNames = BattleMapNames;
                    LocationsInstanses.Add(location.GetComponent<LocationController>().Params);
                }
                Debug.Log("Карта загружена");
                mapSaver.save.LocationsParametrs = LocationsInstanses;
            }
            else
            {
                Debug.Log("Сохранение повреждено или отсутствует");
                mapSaver.SetCompanyProgress(false);
                GenerateGrid();
            }
        }
        else
        {
            float spawnChanse = 5;
            int currLocsCount = 0;
            while (currLocsCount < TargetLocationsCount)
            {
                for (int x = 0; x < mapBounds.size.x; x++)
                {
                    for (int y = 0; y < mapBounds.size.y; y++)
                    {
                        TileBase tile = allTiles[x + y * mapBounds.size.x];
                        if (tile != null && currLocsCount < TargetLocationsCount)
                        {
                            if(Random.Range(0,100) <= spawnChanse)
                            {
                                GameObject loc = Instantiate(Locations[0], new Vector3(x, y), Quaternion.identity);
                                LocationsInstanses.Add(loc.GetComponent<LocationController>().Params);
                                loc.GetComponent<LocationController>().locNames = BattleMapNames;
                                currLocsCount++;
                                spawnChanse = 5;
                            }
                            spawnChanse++;
                        }
                    }
                }
            }
            mapSaver.SaveNewMap(LocationsInstanses);
            mapSaver.SetCompanyProgress(true);

        }
    }
    
}
