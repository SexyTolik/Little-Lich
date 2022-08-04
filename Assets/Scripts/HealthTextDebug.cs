using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthTextDebug : MonoBehaviour
{
    private HeathBeh hb;
    public TextMesh text;
    void Start()
    {
        hb = GetComponentInParent<HeathBeh>();
        text = GetComponent<TextMesh>();
    }
    void Update()
    {
        text.text = hb.Health.ToString() + "hp";
    }
}
