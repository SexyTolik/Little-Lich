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
        CheckSelectedMobs();
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

    public void SaveUpgrades(List<(string, int)> values)
    {
        save.UpgradesData.Clear();
        foreach(var v in values)
        {
            save.UpgradesData.Add(JsonUtility.ToJson(v));
        }
        File.WriteAllText(path, JsonUtility.ToJson(save));
    }

    public List<(string,int)> LoadSavedUpgrades()
    {
        if (save.UpgradesData.Count == 0)
        {
            return null;
        }
        List<(string, int)> result = new List<(string, int)>();
        foreach(var v in save.UpgradesData)
        {
            result.Add(JsonUtility.FromJson<(string,int)>(v));
        }
        return result;
    }

    public void SaveSelectedMobs((string,string) value)
    {
        string ConvertedValue = JsonUtility.ToJson(value);
        save.SelectedMobs = ConvertedValue;
        File.WriteAllText(path, JsonUtility.ToJson(save));
    }

    public void CheckSelectedMobs()
    {
        if (LoadSelectedMobs() == ("", "") || save.PastTime == 0f)
        {
            SaveSelectedMobs(("ZombieData", "ZombieData"));
        }
    }
    public (string,string) LoadSelectedMobs()
    {
        return JsonUtility.FromJson<(string, string)>(save.SelectedMobs);
    }

    public void SaveMoney(int MoneyCount)
    {
        save.Money = MoneyCount;
        File.WriteAllText(path, JsonUtility.ToJson(save));
    }
    public void SaveMoney()
    {
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
    public string SelectedMobs = JsonUtility.ToJson(("",""));
    public List<LocParams> LocationsParametrs;
    public List<string> LocationsData;
    public List<string> UpgradesData = new List<string>();
    public bool CompanyInProgress;
    public float PastTime;
    public int Money;
    
}
