using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Pathfinding;

public class MobMoveToTargetState : BaseMobState
{
    public MobMoveToTargetState(GameObject _target, AIDestinationSetter _setter, MobController _controller)
    {
        targ = _target;
        setter = _setter;
        controller = _controller;

        if (controller.Enemy)
        {
            filter.SetLayerMask(LayerMask.GetMask("Friends"));
        }
        else
        {
            filter.SetLayerMask(LayerMask.GetMask("Enemys"));
        }
    }

    public GameObject targ;
    private AIDestinationSetter setter;
    private MobController controller;

    private Collider2D[] InVissinOverlaps = new Collider2D[1];
    private Collider2D[] InAttackRangeOverlaps = new Collider2D[1];
    private ContactFilter2D filter = new ContactFilter2D();
    public override void Entry()
    {
        controller.Aipath.canMove = true;
        targ = controller.Target;
        setter.target = null;
        setter.target = targ.transform;
    }

    public override void UpdateLogic()
    {
        if (targ == null)
        {
            controller.ChangeCurrState<MobRandomMoveState>();
        }
        int totalOverlaps = Physics2D.OverlapCircle(controller.transform.position, controller.VisionRange, filter, InVissinOverlaps);
        if (totalOverlaps > 0 && InVissinOverlaps[0] == targ.GetComponent<Collider2D>())
        {
           
        }
        else
        {
            // controller.Aipath.canMove = false;
            controller.ChangeCurrState<MobRandomMoveState>();
        }
        int closeOverlaps = Physics2D.OverlapCircle(controller.transform.position, controller.AttakRange-0.1f, filter, InAttackRangeOverlaps);
        if (closeOverlaps > 0)
        {
            controller.Target = InAttackRangeOverlaps[0].gameObject;
            controller.ChangeCurrState<MobAttackState>();
        }

    } 
}
