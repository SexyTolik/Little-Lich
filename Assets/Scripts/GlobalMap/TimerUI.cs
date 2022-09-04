using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class TimerUI : MonoBehaviour
{
    void Start()
    {
        GetComponent<TextMeshProUGUI>().text = CampainTimerController.instance.PastTime.ToString();
    }
}
