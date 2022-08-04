using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GoodGuyCounter : MonoBehaviour
{
    public static GoodGuyCounter instance = null;
    public int TotalFriends;
    public int MaxFriends = 5;

    public TextMeshProUGUI text;
    void Start()
    {
        if (instance == null)
        {
            instance = this;
        }
        else if (instance == this)
        {
            Destroy(gameObject);
        }
    }

    private void Update()
    {
        text.text = TotalFriends.ToString() + "/" + MaxFriends.ToString();
    }

}
