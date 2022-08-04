using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ManaText : MonoBehaviour
{
    private ManaBeh mp;
    public TextMesh text;
    void Start()
    {
        mp = GetComponentInParent<ManaBeh>();
        text = GetComponent<TextMesh>();
    }
    void Update()
    {
        text.text = mp.mana.ToString() + "mp";
    }
}
