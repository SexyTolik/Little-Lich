using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BadGuyCounter : MonoBehaviour
{
    bool IsInfinityArena = false;
    bool IsBattleMap = false;

    bool IsAlreadyDead = false;
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
           // UnitSpawner.instance.TotalMobs++;
        }

    }

    public void IamDead()
    {
        if (!this.gameObject.scene.isLoaded) return;
        if (IsInfinityArena)
        {
            UnitSpawner.instance.EnemyAlive--;
        }

        if (IsBattleMap)
        {
            KillEnemyCount.instance.AddKill();
        }
        IsAlreadyDead= true;
    }
    void OnDestroy()
    {
        if(!IsAlreadyDead)
        {
            IamDead();
        }
        
    }
}
