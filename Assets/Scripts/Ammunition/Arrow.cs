using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Arrow : MonoBehaviour
{
    public float Dmg;
    public float ExpRadius = 1f;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (gameObject.GetComponent<Collider2D>().IsTouchingLayers(LayerMask.GetMask("Obstacls")))
        {
            Destroy(gameObject);
        }
        if (collision.GetComponent<HeathBeh>() != null && (collision.CompareTag("Enemy") || collision.CompareTag("Friend")))
        {
//            Collider2D[] hitObj = Physics2D.OverlapCircleAll(transform.position, ExpRadius);
            Collider2D hitObj = Physics2D.OverlapPoint(transform.position);

//            foreach (Collider2D col in hitObj)
//            {
//                if (col.GetComponent<HeathBeh>() != null)
//                {
//                    if (col.CompareTag("Enemy")) { col.GetComponent<HeathBeh>().Health = Dmg; }
//                    else if (col.CompareTag("Friend")) { col.GetComponent<HeathBeh>().AddHealth(Dmg); }
//                }
//            }
            if (hitObj.GetComponent<HeathBeh>() != null)
            {
                if (hitObj.CompareTag("Enemy")) { hitObj.GetComponent<HeathBeh>().Health = Dmg; }
            }
            Destroy(gameObject);
        }

    }
}
