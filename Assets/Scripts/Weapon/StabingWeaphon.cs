using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StabingWeaphon : Iweapon
{
    public AttakZoneController attakZone; // устанавливается в едиторе
    private Animator anim;
   // private Collider2D atZone;

    private void Start()
    {
     //   atZone = attakZone.gameObject.GetComponent<CapsuleCollider2D>();
        anim = GetComponent<Animator>();
    }
    public override void Attack()
    {
        if (!IsAttacking)
        {
            IsAttacking = true;
            attakZone.CheckColls();
            anim.SetBool("IsAttaking", IsAttacking);
            StartCoroutine(AttDelay());
        }
    }

    public override void MakeDamage(HeathBeh targ)
    {
        targ.Health = Dmg;
    }
    public IEnumerator AttDelay()
    {
        float currDelay = AttackDelay;
        while(currDelay > 0)
        {
            currDelay -= 0.01f;
            yield return new WaitForSeconds(0.01f);
        }
        IsAttacking = false;
        anim.SetBool("IsAttaking", IsAttacking);
    }
}
