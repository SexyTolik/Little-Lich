using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeathBall : MonoBehaviour
{
    public GameObject ExpEffect;
    public float Dmg;
    public float ExpRadius = 1f;

    private void OnTriggerEnter2D(Collider2D collision)
    {
      /*  if (gameObject.GetComponent<Collider2D>().IsTouchingLayers(LayerMask.GetMask("Obstacls")))
        {
            Instantiate(ExpEffect, transform.position, Quaternion.identity);
            Destroy(gameObject);
        } */
        if(collision.CompareTag("Player"))
        {
            Physics2D.IgnoreCollision(collision,gameObject.GetComponent<Collider2D>());
        }
        if(gameObject.GetComponent<Collider2D>().IsTouchingLayers(LayerMask.GetMask("Obstacls")) || collision.GetComponent<HeathBeh>() != null && (collision.CompareTag("Enemy") || collision.CompareTag("Friend")))
        {
            Collider2D[] hitObj = Physics2D.OverlapCircleAll(transform.position, ExpRadius);

            foreach(Collider2D col in hitObj)
            {
                if(col.GetComponent<HeathBeh>() != null)
                {
                    if (col.CompareTag("Enemy")) { col.GetComponent<HeathBeh>().Health = Dmg;}
                    else if (col.CompareTag("Friend")) { col.GetComponent<HeathBeh>().AddHealth(Dmg); }
                }
            }
            GameObject particle = Instantiate(ExpEffect, transform.position, Quaternion.identity);
            var shape = particle.GetComponent<ParticleSystem>().shape;
            shape.radius = ExpRadius;
            Destroy(gameObject);
        }
        
    }
}
