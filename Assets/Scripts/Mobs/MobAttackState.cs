using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Pathfinding;

public class MobAttackState : BaseMobState
{
    public MobAttackState(MobController _controller)
    {
        controller = _controller;
        controller.AttackDelayMethod += MobAttack;
        if (controller.Enemy)
        {
            filter.SetLayerMask(LayerMask.GetMask("Friends"));
        }
        else
        {
            filter.SetLayerMask(LayerMask.GetMask("Enemys"));
        }
    }

    private MobController controller;
    private Coroutine AttackCor;
    private bool IsAttack = false;

    private Collider2D[] InAttackRangeOverlaps = new Collider2D[1];
    private ContactFilter2D filter = new ContactFilter2D();
    public override void Entry()
    {
        controller.Setter.target = null;
        controller.Aipath.IsMoving = false;

    }
    public override void UpdateLogic()
    {
        if(controller.Target == null)
        {
            if (IsAttack)
            {
                controller.StopCoroutine(AttackCor);
            }
            controller.ChangeCurrState<MobRandomMoveState>();
        }
        int closeOverlaps = Physics2D.OverlapCircle(controller.transform.position, controller.AttakRange, filter, InAttackRangeOverlaps);
        if (closeOverlaps > 0 && controller.Target.GetComponent<Collider2D>() == InAttackRangeOverlaps[0])
        {
            if (!IsAttack)
            {
                AttackCor = controller.StartCoroutine(controller.Timer(0.2f, controller.AttackDelayMethod));
                IsAttack = true;
            }
        }
        else
        {
            if (IsAttack)
            {
                controller.StopCoroutine(AttackCor);
            }
            controller.ChangeCurrState<MobRandomMoveState>();
        }
    }

    public override void Exit()
    {
        controller.Aipath.IsMoving = true;
        IsAttack = false;
    }

    public void MobAttack()
    {
        controller.currWeaphon.Attack();
    }
}
