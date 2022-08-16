using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class GlobalMapSaver : MonoBehaviour
{
    public GameSave save = new GameSave();
    private string path;

    void Awake()
    {
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

    public void SaveMap(List<Vector3> cords)
    {
        save.VillageCords = cords;
        save.CompanyInProgress = true;
        File.WriteAllText(path, JsonUtility.ToJson(save));
    }

    public void SetCompanyProgress(bool state)
    {
       save.CompanyInProgress = state;
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
    public List<Vector3> VillageCords;
    public bool CompanyInProgress;
}
