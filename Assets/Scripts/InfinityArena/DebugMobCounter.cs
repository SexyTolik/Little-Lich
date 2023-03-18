using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DebugMobCounter : MonoBehaviour
{
    public Sprite MobToken;
    void Start()
    {
        MobToken = GetComponent<MobController>().CurMob.TokenImage;
        GoodGuyCounter.instance.TotalFriends++;
        GoodGuyCounter.instance.AddMobToken(this);
    }


    void OnDestroy()
    {
        GoodGuyCounter.instance.TotalFriends--;
        GoodGuyCounter.instance.RemoveMobToken(this);
    }
}
