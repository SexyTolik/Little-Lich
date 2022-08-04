using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NpcDirectinController : IDirection
{
    private MobController mobController;

    private void Start()
    {
        mobController = GetComponent<MobController>();
        lastDir = Vector2.down;
    }

    public override Vector2 GetCurrDirection()
    {
        if(mobController.Setter.target != null)
        {
            Vector2 vec2 = mobController.Setter.target.position - transform.position;
            return vec2.normalized;
        }
        else
        {
            return Vector2.zero;
        }
        
        
    }
    private void Update()
    {
        if(GetCurrDirection() != Vector2.zero)
        {
            lastDir = GetCurrDirection();
            IsMoving = true;
        }
        else
        {
            IsMoving = false;
        }
    }
}
