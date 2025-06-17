using System.Collections.Generic;
using UnityEngine;

 /*public class RaysTest : MonoBehaviour
{
    public float speed = 0.04f;
    public Transform TargetToMove;
    public LayerMask filter;

    private CircleCollider2D col;
    private List<WayRay> Rays = new List<WayRay>();
    private Vector2 targetToMove;

    public int RaysCount = 2;
    private float SegmentSize;
    private float angle = 360f;
    void Start()
    {
        filter = LayerMask.GetMask("Obstacls");
        col = GetComponent<CircleCollider2D>();
    }

    private void FixedUpdate()
    {
        targetToMove = (Vector2)TargetToMove.position;
        MakeRays();
        MoveTo(targetToMove);
        
    }

    public void MakeRays()
    {
        Rays.Clear();
        SegmentSize = angle / RaysCount;
        Vector3 StandartVector = Vector3.up;
        for (int i = 1; i <= RaysCount; i++)
        {
            Vector3 rotatedVec = Quaternion.AngleAxis(SegmentSize * i, Vector3.forward)) * StandartVector;
            Rays.Add(new WayRay(rotatedVec, Physics2D.Raycast(transform.position, rotatedVec, col.radius, filter.value)));
            Debug.DrawLine(transform.position, rotatedVec, Color.red);
        }
    }

    public Vector2 SelectDir(Vector2 target)
    {
        WayRay curDir = Rays[0];
        int num = 0;
        foreach (var ray in Rays)
        {
            //Debug.Log("Ray" + num.ToString() + " is " + ray.Hit.point);
            if((target - ray.Hit.point).magnitude < (target - curDir.Hit.point).magnitude)
            {
                curDir = ray;
                Debug.Log("Ray set to " + curDir);
            }
            num++;
        }
        Debug.DrawLine(transform.position, curDir.Direction, Color.blue,5f);
        if (curDir.Hit.point != Vector2.zero)
        {
            Debug.Log(curDir.Hit.point);
            return (curDir.Hit.point - (Vector2)transform.position).normalized;
        }
        else
        {
            Debug.Log("Залупа");
            return curDir.Direction.normalized;
        }
        
    }

    public void MoveTo(Vector2 target)
    {
        if (target != null && Mathf.Round(transform.position.x) != Mathf.Round(target.x) && Mathf.Round(transform.position.y) != Mathf.Round(target.y))
        {
            Debug.Log("Target in " + target);
            var dir = SelectDir(target) * speed;
            Debug.Log("Dir is " + dir);
            transform.position += new Vector3(dir.x, dir.y);
            Debug.Log("MoveTo " + dir);
        }
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
} */