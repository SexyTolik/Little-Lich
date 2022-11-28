using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BadGuyCounter : MonoBehaviour
{
    bool IsInfinityArena = false;
    bool IsBattleMap = false;
    private void Start()
    {
        if(UnitSpawner.instance != null)
        {
            IsInfinityArena = true;
        }

        if(KillEnemyCount.instance != null)
        {
            IsBattleMap = true;
        }

        if (IsInfinityArena)
        {
            UnitSpawner.instance.TotalMobs++;
        }

    }

    void OnDestroy()
    {
        if (!this.gameObject.scene.isLoaded) return;
        if (IsInfinityArena)
        {
            UnitSpawner.instance.TotalMobs--;
        }

        if (IsBattleMap)
        {
            KillEnemyCount.instance.AddKill();
        }


    }
}
