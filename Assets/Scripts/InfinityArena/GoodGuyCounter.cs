using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using System;

public class GoodGuyCounter : MonoBehaviour
{
    public static GoodGuyCounter instance = null;
    public int TotalFriends;
    public int MaxFriends = 5;

    //private List<DebugMobCounter> CurMobs = new List<DebugMobCounter>();
    private DebugMobCounter[] CurMobs;
    public List<Image> TokensImages = new List<Image>();
    public Sprite EmptyTokenSprite;
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
        CurMobs = new DebugMobCounter[MaxFriends];
    }

    public void AddMobToken(DebugMobCounter tic)
    {
        TokensImages[PutMobIn(tic)].sprite = tic.MobToken;
    }

    public void RemoveMobToken(DebugMobCounter tok)
    {
        int mobIndex = Array.IndexOf(CurMobs, tok);
        TokensImages[mobIndex].sprite = EmptyTokenSprite;
        CurMobs[mobIndex] = null;
    }

    private int PutMobIn(DebugMobCounter mob)
    {
        for(int i = 0; i < CurMobs.Length; i++)
        {
            if (CurMobs[i] == null)
            {
                CurMobs[i] = mob;
                return i;
            }
        }
        return 0;
    }
}
