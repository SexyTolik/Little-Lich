using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KillEnemyCount : WinTrigger
{
    public static KillEnemyCount instance;

    public int TargetKillCount = 10;
    private int currentKillCount = 0;

    private void Start()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(this);
        }
    }

    public void AddKill()
    {
        currentKillCount++;
        if(currentKillCount >= TargetKillCount)
        {
            MapWin();
        }
    }
}
