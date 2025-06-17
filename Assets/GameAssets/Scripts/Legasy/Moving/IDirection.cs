using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public abstract class IDirection : MonoBehaviour
{
    public virtual Vector2 GetCurrDirection()
    {
        return Vector2.zero;
    }
    public bool IsMoving;
    public Vector2 lastDir;

}
