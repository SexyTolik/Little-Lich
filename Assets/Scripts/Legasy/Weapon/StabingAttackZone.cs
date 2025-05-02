using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StabingAttackZone : AttakZoneController
{
    private StabingWeaphon curWeaphon;

    void Start()
    {
        dir = gameObject.GetComponentInParent<IDirection>();
        capCol = GetComponent<CircleCollider2D>();
        curWeaphon = dir.GetComponentInChildren<StabingWeaphon>();
        if (dir.gameObject.CompareTag("Enemy"))
        {
           // ememy = true;
            filter.SetLayerMask(LayerMask.GetMask("Friends"));
        }
        else
        {
          //  ememy = false;
            filter.SetLayerMask(LayerMask.GetMask("Enemys"));
        }
    }
    public override void CheckColls()
    {
        //int closeOverlaps = Physics2D.OverlapCapsule(transform.position + (Vector3)capCol.offset, capCol.size, capCol.direction, transform.rotation.z, filter, InAttackRangeOverlaps);
        int closeOverlaps = Physics2D.OverlapCircle(transform.position + (Vector3)capCol.offset, 2f, filter, InAttackRangeOverlaps);
        if (closeOverlaps > 0)
        {
            Collider2D nearestCol = InAttackRangeOverlaps[0];
            ColliderDistance2D closestDist = Physics2D.Distance(nearestCol, capCol);
            foreach(var cols in InAttackRangeOverlaps)
            {
                if(Physics2D.Distance(cols,capCol).distance < closestDist.distance)
                {
                    nearestCol = cols;
                }
            }
            curWeaphon.MakeDamage(nearestCol.GetComponent<HeathBeh>());
            nearestCol.GetComponent<Rigidbody2D>().AddForce(dir.lastDir.normalized * discardingForce, ForceMode2D.Impulse);
        }        
    }

}
