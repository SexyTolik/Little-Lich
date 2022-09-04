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

    }
    
    public void MapComplite()
    {
        CurLoc.locationComplite = true;
        Debug.Log("Карта пройдена как" + CurLoc.locationComplite);
        CampainTimerController.instance.SaveTime();
        GlobalMapSaver.instance.ResaveMap();
        Debug.Log("Пройденая карта записалась как " + GlobalMapSaver.instance.save.LocationsData);
        CurLoc = null;
        CheckAllLocProgress();
    }

    public void CheckAllLocProgress()
    {
        var SavedLocParams = GlobalMapSaver.instance.save.LocationsParametrs;
        foreach(var sav in SavedLocParams)
        {
            if (sav.locationComplite)
            {

            }
            else
            {
                return;
            }
        }
        CompanyInProgress = false;
        Debug.Log("Все локации пройдены");
    }
}
