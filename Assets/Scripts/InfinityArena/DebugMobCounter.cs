using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DebugMobCounter : MonoBehaviour
{

    void Start()
    {
        GoodGuyCounter.instance.TotalFriends++;
    }


    void OnDestroy()
    {
        GoodGuyCounter.instance.TotalFriends--;
    }
}
