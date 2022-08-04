using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Pathfinding;
using System.Timers;

public class MobRandomMoveState : BaseMobState
{
    private AIDestinationSetter setter;
    private CircleCollider2D movezone;
    private GameObject pointer;
    private MobController controller;
    private AIPath iPath;

    private ContactFilter2D filter = new ContactFilter2D();
    private Collider2D[] overlaps = new Collider2D[1];
    private RaycastHit2D hit2D;

    private Coroutine timer;
    public MobRandomMoveState(AIDestinationSetter _setter, CircleCollider2D _movezone, GameObject _pointer, MobController _controller, AIPath aIPath)
    {
        setter = _setter;
        movezone = _movezone;
        pointer = _pointer;
        controller = _controller;
        iPath = aIPath;
        pointer.transform.parent = null;
        if (controller.Enemy)
        {
            filter.SetLayerMask(LayerMask.GetMask("Friends"));
        }
        else
        {
            filter.SetLayerMask(LayerMask.GetMask("Enemys"));
        }
        
        controller.DelayMethod = ChoceRandPoint;
    }

    public override void Entry()
    {
        setter.target = null;
        timer = controller.StartCoroutine(controller.Timer(controller.RandomMoveChangePointTime, controller.DelayMethod));
    }
    private void ChoceRandPoint()
    {
        if(!iPath.canMove) { controller.Aipath.canMove = true; }
        setter.target = randomPointInBounds();
    }
    private Transform randomPointInBounds()
    {
        Transform ret = pointer.transform;
        ret.rotation = Quaternion.identity;
        ret.position = new Vector3(Random.Range(movezone.bounds.min.x, movezone.bounds.max.x), Random.Range(movezone.bounds.min.y, movezone.bounds.max.y));

        return ret;
    }
    public override void UpdateLogic()
    {
        int totalOverlaps = Physics2D.OverlapCircle(controller.transform.position, controller.VisionRange, filter, overlaps);
        if (totalOverlaps > 0)
        {
            controller.Target = overlaps[0].gameObject;
            controller.ChangeCurrState<MobMoveToTargetState>();
        }

        hit2D = Physics2D.Raycast(controller.transform.position, iPath.steeringTarget - controller.transform.position, 1f,LayerMask.GetMask("Obstacls"));
        if(hit2D)
        {
         //   setter.target = controller.transform;
            setter.target = randomPointInBounds();
        }
    }

    public override void Exit()
    {
        controller.StopCoroutine(timer);
    }
}
