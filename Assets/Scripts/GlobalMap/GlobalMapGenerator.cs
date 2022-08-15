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
    BoundsInt mapBounds;
    private ProgressController progContr;
    private GlobalMapSaver mapSaver;
    public List<Vector3> LocationsCords = new List<Vector3>();
    void Start()
    {
        progContr = GetComponent<ProgressController>();
        mapSaver = GetComponent<GlobalMapSaver>();
        mapBounds = tilemap.cellBounds;
        allTiles = tilemap.GetTilesBlock(mapBounds);

        GenerateGrid();
    }

    private void GenerateGrid()
    {
        if (progContr.CompanyInProgress)
        {
            if (mapSaver.loadMap())
            {
                foreach(Vector3 cord in mapSaver.save.VillageCords)
                {
                    Instantiate(Locations[0], cord, Quaternion.identity);
                }
                Debug.Log("Карта загружена");
            }
            else
            {
                Debug.Log("Сохранение повреждено или отсутствует");
                progContr.CompanyInProgress = false;
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
                                Instantiate(Locations[0], new Vector3(x, y), Quaternion.identity);
                                LocationsCords.Add(new Vector3(x, y));
                                currLocsCount++;
                                spawnChanse = 5;
                            }
                            spawnChanse++;
                        }
                    }
                }
            }
            mapSaver.SaveMap(LocationsCords);
            progContr.CompanyInProgress = true;
        }
    }
    
}
