using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IsMoveble
{
    bool IsMoving { get; set; }
    Vector3 SteeringTarget { get; }
    public float Speed { get; set; }
}
