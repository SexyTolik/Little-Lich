using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class GlobalMapSaver : MonoBehaviour
{
    public static GlobalMapSaver instance;

    public GameSave save = new GameSave();
    private string path;
    void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(this);
        }
        DontDestroyOnLoad(this);

#if !UNITY_EDITOR
        path = Path.Combine(Application.persistentDataPath, "Save.json");
#else
        path = Path.Combine(Application.dataPath, "Save.json");
#endif
        loadMap();
    }

    public bool loadMap()
    {
        if (File.Exists(path))
        {
            save = JsonUtility.FromJson<GameSave>(File.ReadAllText(path));
            return true;
        }
        else
        {
            return false;
        }
    }

    public void SaveNewMap(List<LocParams> locs)
    {
        save.LocationsParametrs = locs;
        save.CompanyInProgress = true;
        save.LocationsData = new List<string>();
        
        foreach (LocParams l in locs)
        {
            save.LocationsData.Add(JsonUtility.ToJson(l));
        }

        File.WriteAllText(path, JsonUtility.ToJson(save));
    }

    public void ResaveMap()
    {
        save.LocationsData.Clear();
        foreach (LocParams l in save.LocationsParametrs)
        {
            save.LocationsData.Add(JsonUtility.ToJson(l));
        }
        File.WriteAllText(path, JsonUtility.ToJson(save));
    }

    public void SetCompanyProgress(bool state)
    {
       save.CompanyInProgress = state;
        ProgressController.instance.CompanyInProgress = state;
       File.WriteAllText(path, JsonUtility.ToJson(save));
    }

    public bool CheckCompanyProgress()
    {
        if (File.Exists(path))
        {
            Debug.Log("Чекер нашел сейв и прогрес = " + save.CompanyInProgress);
            return save.CompanyInProgress;
        }
        else
        {
            Debug.Log("ненаход");
            return false;
        }
    }
}
[SerializeField]
public class GameSave
{
    public List<LocParams> LocationsParametrs;
    public List<string> LocationsData;
    public bool CompanyInProgress;
    public float PastTime;
}
