using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class TimerUI : MonoBehaviour
{
    void Start()
    {
        int time = (int)CampainTimerController.instance.PastTime;
        GetComponent<TextMeshProUGUI>().text = time.ToString() + "sec";
    }
}
