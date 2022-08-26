using System.IO;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RangeAttackZone : AttakZoneController
{
    private RangeWeapon curWeaphon;

    void Start()
    {
        dir = gameObject.GetComponentInParent<IDirection>();
        curWeaphon = dir.GetComponentInChildren<RangeWeapon>();
        capCol = GetComponent<CircleCollider2D>();
        if (dir.gameObject.CompareTag("Enemy"))
        {
            filter.SetLayerMask(LayerMask.GetMask("Friends"));
        }
        else
        {
            filter.SetLayerMask(LayerMask.GetMask("Enemys"));
        }
    }

    public override void CheckColls()
    {
        int closeOverlaps = Physics2D.OverlapCircle(transform.position + (Vector3)capCol.offset, capCol.radius, filter, InAttackRangeOverlaps);
        if (closeOverlaps > 0)
        {
            Debug.Log("Выстрелил");
            Collider2D nearestCol = InAttackRangeOverlaps[0];
            ColliderDistance2D closestDist = Physics2D.Distance(nearestCol, capCol);
            foreach(var cols in InAttackRangeOverlaps)
            {
                if(Physics2D.Distance(cols,capCol).distance < closestDist.distance)
                {
                    nearestCol = cols;
                }
            }
            var projectileDirection = nearestCol.transform.position - transform.position;
            dir.lastDir = projectileDirection;

            GameObject proj = Instantiate(curWeaphon.Projectile, transform.position, transform.rotation);
            proj.transform.right = projectileDirection;
            proj.GetComponent<Rigidbody2D>().velocity = projectileDirection.normalized * curWeaphon.ProjtileSpeed;
        }        
    }

}
