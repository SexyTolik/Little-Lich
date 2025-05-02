using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Iweapon : MonoBehaviour // ����� �� �������, ����� ��� � ������ ������ ���� ������ ������ ����� ������ ���
{
    public float Dmg;
    public float AttackDelay;
    public bool IsAttacking = false;
    public virtual void Attack()
    {

    }
    public virtual void MakeDamage(HeathBeh targ)
    {

    }
}
