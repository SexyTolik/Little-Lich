using Pathfinding;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class RayMovement : MonoBehaviour, IsMoveble
{
    public float RayDistance = 2f;
    public LayerMask TargerLayer;

    public int rayCount = 8;
    private float segmentSize;

    // ���� ���������� ��� ������������
    public float speed = 2f;
    public float Speed { get => speed; set => speed = value; }
    public Rigidbody2D Rb;
    public float MoveDelay = 1f;
    public bool canMove = true;
    public bool IsMoving{get{return canMove;} set{canMove = value;}}
    Vector3 steeringTarget;
    public Vector3 SteeringTarget{get { return steeringTarget; }}
    private AIDestinationSetter setter;
    public IEnumerator MakeMove()
    {
        while (true)
        {
            if(canMove && setter.target != null) {GoNahui();} //else { Rb.velocity= Vector3.zero; }
            yield return new WaitForSeconds(MoveDelay);
        }
       
    }
    void Start()
    {
        Rb = GetComponent<Rigidbody2D>();
        setter= GetComponent<AIDestinationSetter>();
        StartCoroutine(MakeMove());
    }

    private void FixedUpdate()
    {
       // GoNahui();
    }

    private WayRay[] MakeRays()
    {
        segmentSize = 360 / rayCount;
        Vector3 StandartVector = Vector3.up;
        WayRay[] rayHits = new WayRay[rayCount];
        for (int i = 1; i <= rayCount; i++)
        {
            Vector3 rotatedVec = Quaternion.AngleAxis(segmentSize * i, Vector3.forward) * StandartVector;
            rayHits[i-1] = new WayRay(rotatedVec, Physics2D.Raycast(transform.position, rotatedVec, RayDistance, TargerLayer.value));
            Debug.DrawLine(transform.position, (rotatedVec * RayDistance) + transform.position, Color.red, MoveDelay);
        }
        return rayHits;
    }

    public Vector3 SelectDir(Transform targ)
    {
        Vector3 result;
        bool isCollided = false;

        WayRay[] rays = MakeRays();
        foreach (var ray in rays)
        {
            if(ray.Hit.collider != null) { isCollided = true; }
        }
        if (isCollided)
        {
            WayRay curDir = rays[0];
            int badWays = 0;
            foreach (var ray in rays)
            {
                if(ray.Hit.collider == null)
                {
                    if((targ.position - ((Vector3)curDir.Direction + transform.position)).magnitude > (targ.position - ((Vector3)ray.Direction + transform.position)).magnitude)
                    {
                        curDir = ray;
                    }
                }
                else
                {
                    badWays++;
                }
            }
            if(badWays == rayCount)
            {
                foreach(var ray in rays)
                {
                    if ((targ.position - (Vector3)ray.Hit.point).magnitude < (targ.position - (Vector3)curDir.Hit.point).magnitude)
                    {
                        curDir = ray;
                        Debug.Log("������");
                    }
                }
            }
            result = (Vector3)curDir.Direction.normalized;
            Debug.DrawLine(transform.position, result + transform.position, Color.blue, MoveDelay);
        }
        else
        {
            result = (targ.position - transform.position).normalized;
            Debug.DrawLine(transform.position, result + transform.position, Color.blue, MoveDelay);
        }
        steeringTarget = result + transform.position;
        return result;
    }

    public void GoNahui()
    {
        Rb.linearVelocity = SelectDir(setter.target) * speed;
    }
}

public struct WayRay
{
    public Vector2 Direction;
    public RaycastHit2D Hit;

    public WayRay(Vector2 dir, RaycastHit2D hit)
    {
        Direction = dir;
        Hit = hit;
    }
}