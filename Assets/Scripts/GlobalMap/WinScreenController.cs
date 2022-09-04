using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class WinScreenController : MonoBehaviour
{
    public GameObject WinScreen;
    public TextMeshProUGUI timerText;
    
    public void WinScreenActive()
    {
        WinScreen.SetActive(true);
        timerText.text = CampainTimerController.instance.PastTime.ToString();
        CampainTimerController.instance.PastTime = 0f;
    }

    void Start()
    {
        if (!ProgressController.instance.CompanyInProgress)
        {
            WinScreenActive();
            GlobalMapSaver.instance.SetCompanyProgress(false);
        }
    }
}
