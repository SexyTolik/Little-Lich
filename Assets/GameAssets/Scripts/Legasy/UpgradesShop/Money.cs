using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Money : MonoBehaviour
{
    public TextMeshProUGUI MoneyText;
    private int _moneyCount;
    public int MoneyCount
    {
        get => _moneyCount;
        set
        {
            _moneyCount = Mathf.Clamp(value, 0, 9999);
            GlobalMapSaver.instance.SaveMoney(_moneyCount);
            MoneyText.text = MoneyCount.ToString();

        }
    }

    private void Start()
    {
        MoneyCount = GlobalMapSaver.instance.save.Money;
        MoneyText.text = MoneyCount.ToString();
    }
}
