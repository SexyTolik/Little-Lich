using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttakZoneController : MonoBehaviour
{
    private IDirection dir;
    private StabingWeaphon curWeaphon;

    private float discardingForce = 200;
   // private bool ememy;
    private ContactFilter2D filter = new ContactFilter2D();
    private List<Collider2D> InAttackRangeOverlaps = new List<Collider2D>();
    private CircleCollider2D capCol;
    public float DiscardingForce
    {
        get => discardingForce;
        set => Mathf.Clamp(value, 0f, 1500f);
    }
    void Start()
    {
        dir = gameObject.GetComponentInParent<IDirection>();
        curWeaphon = dir.GetComponentInChildren<StabingWeaphon>();
        capCol = GetComponent<CircleCollider2D>();
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
   
    void Update()
    {
        Quaternion toRotation = Quaternion.LookRotation(Vector3.forward, -dir.lastDir);
        transform.rotation = toRotation;
    }

    /* private void OnTriggerEnter2D(Collider2D collision)
     {
         if (ememy)
         {
             if (collision.GetComponent<HeathBeh>() != null && collision.CompareTag("Friend") || collision.CompareTag("Player") && curWeaphon.IsAttacking)
             {
                 curWeaphon.MakeDamage(collision.gameObject.GetComponent<HeathBeh>());
                 collision.GetComponent<Rigidbody2D>().AddForce(dir.lastDir.normalized * discardingForce, ForceMode2D.Impulse);
                 GetComponent<CapsuleCollider2D>().enabled = false;
                 GetComponent<AttakZoneController>().enabled = false;
             }
         }
         else
         {
             if (collision.GetComponent<HeathBeh>() != null && collision.CompareTag("Enemy") && curWeaphon.IsAttacking)
             {
                 curWeaphon.MakeDamage(collision.gameObject.GetComponent<HeathBeh>());
                 collision.GetComponent<Rigidbody2D>().AddForce(dir.lastDir.normalized * discardingForce, ForceMode2D.Impulse);
                 GetComponent<CapsuleCollider2D>().enabled = false;
                 GetComponent<AttakZoneController>().enabled = false;
             }
         }

     } */

    public void CheckColls()
    {
        //int closeOverlaps = Physics2D.OverlapCapsule(transform.position + (Vector3)capCol.offset, capCol.size, capCol.direction, transform.rotation.z, filter, InAttackRangeOverlaps);
        int closeOverlaps = Physics2D.OverlapCircle(transform.position + (Vector3)capCol.offset, 2f, filter, InAttackRangeOverlaps);
        if (closeOverlaps > 0)
        {
            Debug.Log("Уебал");
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
