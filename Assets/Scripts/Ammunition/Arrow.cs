using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Arrow : MonoBehaviour
{
    public float Dmg;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (gameObject.GetComponent<Collider2D>().IsTouchingLayers(LayerMask.GetMask("Obstacls")))
        {
            Destroy(gameObject);
        }
        if (collision.GetComponent<HeathBeh>() != null && (collision.CompareTag("Player") || collision.CompareTag("Friend")))
        {
            Collider2D[] hitObj = Physics2D.OverlapCircleAll(transform.position, 1f);

            foreach(Collider2D col in hitObj)
            {
                if(col.GetComponent<HeathBeh>() != null)
                {
                    if (col.CompareTag("Player")) { col.GetComponent<HeathBeh>().Health = Dmg;}
                    else if (col.CompareTag("Friend")) { col.GetComponent<HeathBeh>().Health = Dmg; }
                }
            }
            Destroy(gameObject);
        }

    }
}
