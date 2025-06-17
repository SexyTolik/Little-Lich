using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Pathfinding;

// ������� AIpath ��� ���� ����� ��� ����� ���� �������� �� RayMovement � ��������
public class AstarMovement : AIPath, IsMoveble
{
    
    public bool IsMoving
    {
        get
        {
            return canMove;
        }

        set
        {
            canMove = value;
        }
    }

    public Vector3 SteeringTarget
    {
        get { return steeringTarget; }
    }

    public float Speed { get => maxSpeed; set => maxSpeed = value; }
}
