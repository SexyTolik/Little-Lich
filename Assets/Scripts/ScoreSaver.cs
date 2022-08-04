using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreSaver : MonoBehaviour
{
    public static ScoreSaver instance = null;

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
    }

    public void SaveScore(int num, string location)
    {
        PlayerPrefs.SetInt(location, num);
    }
    public int ShowScore(string location)
    {
      return PlayerPrefs.GetInt(location);
    }
}
