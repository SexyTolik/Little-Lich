using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FortressReward : MapReward
{
    public override void GiveReward()
    {
        Debug.Log("�� ����������� ���� �������� " + MoneyReward + "�����");
        GlobalMapSaver.instance.save.Money += (int)MoneyReward;
        GlobalMapSaver.instance.SaveMoney();
        Debug.Log("� ��� �������� ����� �� �� �����(��� �� ��������)");
    }
}
