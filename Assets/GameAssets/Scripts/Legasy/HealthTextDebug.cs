using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthTextDebug : MonoBehaviour
{
    private HeathBeh hp;
    private Slider fillbar;
    void Start()
    {
        hp = GetComponentInParent<HeathBeh>();
        fillbar = GetComponent<Slider>();
        fillbar.maxValue = hp.MaxHealth;
        fillbar.value = fillbar.maxValue;
    }
    void Update()
    {
        fillbar.value = hp.Health;
    }

}
