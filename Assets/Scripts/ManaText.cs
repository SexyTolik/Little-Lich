using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ManaText : MonoBehaviour
{
    private ManaBeh mana;
    private Slider fillbar;
    void Start()
    {
        mana = GameObject.Find("Player").GetComponentInParent<ManaBeh>();
        fillbar = GetComponent<Slider>();
        fillbar.maxValue = mana.MaxMana;
        fillbar.value = fillbar.maxValue;
    }
    void Update()
    {
        fillbar.value = mana.mana;
    }
}
