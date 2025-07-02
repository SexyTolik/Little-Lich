using System;
using UnityEngine;

public interface IAttack
{
    void Execute(Vector2 direction, Transform attacker);
}
