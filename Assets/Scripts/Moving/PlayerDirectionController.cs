using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDirectionController : IDirection
{
    private FixedJoystick Jstick;
    void Start()
    {
        Jstick = GameObject.FindGameObjectWithTag("Joystick").GetComponent<FixedJoystick>();
        lastDir = Vector2.down;
    }

    public override Vector2 GetCurrDirection()
    {
         return Jstick.Direction;
    }

    private void Update()
    {
        if(Jstick.Direction != Vector2.zero)
        {
            lastDir = Jstick.Direction;
            IsMoving = true;
        }
        else
        {
            IsMoving = false;
        }
    }
}
