using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class PlayerValuesStorage : MonoBehaviour
{
    public static PlayerValuesStorage instance;
    [SerializeField]
    int moneyValue = 0;
    public int MoneyValue { get { return moneyValue; } set { moneyValue = value; Text.text = moneyValue.ToString(); } }

    public TextMeshProUGUI Text;
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

        Text.text = moneyValue.ToString();
    }

    public bool TryBuy(int cost)
    {
        if(MoneyValue - cost >= 0)
        {
            MoneyValue -= cost;
            return true;
        }
        else
        {
            return false;
        }
    }
}
