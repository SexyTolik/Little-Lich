using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHpBar : MonoBehaviour
{
    private HeathBeh health;
    private Slider fillbar;
    void Start()
    {
        health = GameObject.Find("Player").GetComponentInParent<HeathBeh>();
        fillbar = GetComponent<Slider>();
        fillbar.maxValue = health.MaxHealth;
        fillbar.value = fillbar.maxValue;
    }
    void Update()
    {
        fillbar.value = health.Health;
    }
}
