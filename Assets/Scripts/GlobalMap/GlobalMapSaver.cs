using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class GlobalMapSaver : MonoBehaviour
{
    public MapSave save = new MapSave();
    private string path;
    
    void Start()
    {
#if !UNITY_EDITOR
        path = Path.Combine(Application.persistentDataPath, "Save.json");
#else
        path = Path.Combine(Application.dataPath, "Save.json");
#endif

    }

    public bool loadMap()
    {
        if (File.Exists(path))
        {
            save = JsonUtility.FromJson<MapSave>(File.ReadAllText(path));
            return true;
        }
        else
        {
            return false;
        }
    }

    public void SaveMap(List<Vector3> cords)
    {
        save.VillageCords = cords;
    }

}
[SerializeField]
public class MapSave
{
    public List<Vector3> VillageCords;
}
