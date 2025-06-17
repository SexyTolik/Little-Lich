using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CampainTimerController : MonoBehaviour
{
    public float PastTime;
    public bool MapIsRun = false;

    public static CampainTimerController instance;
    void Start()
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
        LoadTime();
    }

    public void FixedUpdate()
    {
        if (MapIsRun)
        {
            PastTime += Time.fixedDeltaTime;
        }
    }

    public void SaveTime()
    {
        GlobalMapSaver.instance.save.PastTime = PastTime;
    }
    public void LoadTime()
    {
        PastTime = GlobalMapSaver.instance.save.PastTime;
    }
}
