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
            collision.GetComponent<HeathBeh>().Health = Dmg;
            Destroy(gameObject);
        }

    }
}
