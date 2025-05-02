using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoadingScreenHandler : MonoBehaviour
{
    public GameObject LoadScreen;
    void Start()
    {
       // LoadScreen = GameObject.Find("Loading");
        LoadScreen.SetActive(false);
    }

}
