using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class GlobalMapGenerator : MonoBehaviour
{/// <summary>
/// 0-������� 1-�������� 2-�����
/// </summary>
    [Header("����������� ���������� �������� � �������")]
    public List<GameObject> Locations = new List<GameObject>(2); // ����� �������� ������� �������, ��� ���� ����� �� �������� ��� ������� ��������� ������� � ������� 0-�������,1-��������,2-�����
    public int VillageCount = 5;
    public int FortressCount = 3;
    public int TargetLocationsCount = 8;
    public Tilemap tilemap;


    private TileBase[] allTiles;
    private BoundsInt mapBounds;
    private List<LocParams> LocationsInstanses = new List<LocParams>();
    private GlobalMapSaver mapSaver;
    private List<string> BattleMapNames = new List<string>();

    public bool[,] placedLocs;
    void Awake()
    {
        mapSaver = GlobalMapSaver.instance;
        mapBounds = tilemap.cellBounds;
        allTiles = tilemap.GetTilesBlock(mapBounds);
        placedLocs = new bool[mapBounds.size.x, mapBounds.size.y];

        Object[] locs = Resources.LoadAll("Locations");
        foreach (Object loc in locs)
        {
            Debug.Log(loc.name + "���������");
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
                   GameObject location = Instantiate(Locations[lpar.LocTypeNum], lpar.LocPos, Quaternion.identity);
                   location.GetComponent<LocationController>().Params.locationComplite = lpar.locationComplite;
                   location.GetComponent<LocationController>().locNames = BattleMapNames;
                    LocationsInstanses.Add(location.GetComponent<LocationController>().Params);
                }
                Debug.Log("����� ���������");
                mapSaver.save.LocationsParametrs = LocationsInstanses;
            }
            else
            {
                Debug.Log("���������� ���������� ��� �����������");
                mapSaver.SetCompanyProgress(false);
                GenerateGrid();
            }
        }
        else
        {
            float spawnChanse = 5;
            int currLocsCount = 0;
            int curVillageCount = 0;
            int curFortressCount = 0;

            while (currLocsCount < TargetLocationsCount)
            {
                for (int x = 0; x < mapBounds.size.x; x++)
                {
                    for (int y = 0; y < mapBounds.size.y; y++)
                    {
                        TileBase tile = allTiles[x + y * mapBounds.size.x];
                        if (tile != null && currLocsCount < TargetLocationsCount)
                        {
                            if(Random.Range(0,100) <= spawnChanse && !placedLocs[x,y])
                            {
                                GameObject loc;
                                if (curVillageCount < VillageCount)
                                {
                                     loc = Instantiate(Locations[0], new Vector3(x, y), Quaternion.identity);
                                    curVillageCount++;
                                    Debug.Log("������� ������, ������� ����� = " + currLocsCount.ToString() + "� ���������� = " + TargetLocationsCount.ToString());
                                }
                                else
                                {
                                     loc = Instantiate(Locations[1], new Vector3(x, y), Quaternion.identity);
                                    curFortressCount++;
                                    Debug.Log("������� ��������");
                                }
                                LocationsInstanses.Add(loc.GetComponent<LocationController>().Params);
                                loc.GetComponent<LocationController>().locNames = BattleMapNames;
                                placedLocs[x, y] = true;
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
