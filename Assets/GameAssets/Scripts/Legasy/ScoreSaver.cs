using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class ScoreSaver : MonoBehaviour
{
    public static ScoreSaver instance = null;
    public ScoreSave save = new ScoreSave();
    private string path;

    void Start()
    {
        if (instance == null)
        {
            instance = this;
        }
        else if (instance == this)
        {
            Destroy(gameObject);
        }
        DontDestroyOnLoad(gameObject);

#if !UNITY_EDITOR
        path = Path.Combine(Application.persistentDataPath, "ScoreSave.json");
#else
        path = Path.Combine(Application.dataPath, "ScoreSave.json");
    #endif
    loadScore();
}

    public void SaveScore(int score)
    {
        save.Score = score;
        File.WriteAllText(path, JsonUtility.ToJson(save));
    }
    public int ShowScore()
    {
        if (loadScore())
        {
            return save.Score;
        }
        else
        {
            return 0;
        }
        
    }

    public bool loadScore()
    {
        if (File.Exists(path))
        {
            save = JsonUtility.FromJson<ScoreSave>(File.ReadAllText(path));
            return true;
        }
        else
        {
            return false;
        }
    }
}

[SerializeField]
public class ScoreSave
{
    public int Score;
}
