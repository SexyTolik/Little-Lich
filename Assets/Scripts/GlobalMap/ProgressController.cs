using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class ProgressController : MonoBehaviour
{
    public bool CompanyInProgress = false;
    private string savePath;

    private GlobalMapSaver mapSaver;
    // Start is called before the first frame update
    void Awake()
    {
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

        mapSaver = GetComponent<GlobalMapSaver>();
    }
    
    
}
