using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VillageReward : MapReward
{
    public override void GiveReward()
    {
        Debug.Log("�� ����������� ���� �������� " + MoneyReward + "�����");
        GlobalMapSaver.instance.save.Money += (int)MoneyReward;
        GlobalMapSaver.instance.SaveMoney();
    }
}
