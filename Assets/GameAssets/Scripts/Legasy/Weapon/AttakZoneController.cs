using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttakZoneController : MonoBehaviour
{
    public IDirection dir;
    public float discardingForce = 200;
   // private bool ememy;
    public ContactFilter2D filter = new ContactFilter2D();
    public List<Collider2D> InAttackRangeOverlaps = new List<Collider2D>();
    public CircleCollider2D capCol;
    public float DiscardingForce
    {
        get => discardingForce;
        set => Mathf.Clamp(value, 0f, 1500f);
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

    public virtual void CheckColls()
    {

    }
}
