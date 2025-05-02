using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FortressReward : MapReward
{
    public override void GiveReward()
    {
        Debug.Log("За прохождение локи получено " + MoneyReward + "деняг");
        GlobalMapSaver.instance.save.Money += (int)MoneyReward;
        GlobalMapSaver.instance.SaveMoney();
        Debug.Log("и вот предметы какие то на выбор(еще не закожено)");
    }
}
