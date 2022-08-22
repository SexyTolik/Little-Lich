using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WinTrigger : MonoBehaviour
{
    public GameObject WinScreen;

    public void MapWin()
    {
        WinScreen.SetActive(true);
        ProgressController.instance.MapComplite();
    }
}
