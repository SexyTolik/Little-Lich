using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FortressReward : MapReward
{
    public override void GiveReward()
    {
        Debug.Log("�� ����������� ���� �������� " + MoneyReward + "�����");
        // ��� ��� ��������� �����
        Debug.Log("� ��� �������� ����� �� �� �����(��� �� ��������)");
    }
}
