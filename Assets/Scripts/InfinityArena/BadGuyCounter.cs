using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BadGuyCounter : MonoBehaviour
{
    bool IsInfinityArena = false;
    private void Start()
    {
        if(UnitSpawner.instance != null)
        {
            IsInfinityArena = true;
        }

        if (IsInfinityArena)
        {
            UnitSpawner.instance.TotalMobs++;
        }

    }

    void OnDestroy()
    {
        if (!this.gameObject.scene.isLoaded) return;
        UnitSpawner.instance.TotalMobs--;
        UnitSpawner.instance.score += Random.Range(1,5);
    }
}
