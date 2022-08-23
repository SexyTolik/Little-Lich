using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class ProgressController : MonoBehaviour
{
    public static ProgressController instance;


    public bool CompanyInProgress = false;
    private string savePath;

    public LocParams CurLoc;

    private GlobalMapSaver mapSaver;
    void Awake()
    {
        if(instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(this);
        }
        DontDestroyOnLoad(this);
#if !UNITY_EDITOR
        savePath = Path.Combine(Application.persistentDataPath, "Save.json");
#else
        savePath = Path.Combine(Application.dataPath, "Save.json");
#endif

        if (File.Exists(savePath))
        {
            GameSave save = JsonUtility.FromJson<GameSave>(File.ReadAllText(savePath));
            CompanyInProgress = save.CompanyInProgress;
        }

        mapSaver = GlobalMapSaver.instance;
    }
    
    public void MapComplite()
    {
        CurLoc.locationComplite = true;
        Debug.Log("Карта пройдена" + CurLoc.locationComplite);
        mapSaver.ResaveMap();
        Debug.Log("Пройденая карта записалась как " + mapSaver.save.LocationsData);
        CurLoc = null;
    }
}
