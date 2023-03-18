using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PassPlayer : MonoBehaviour
{
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.CompareTag("Player"))
        {
            Physics2D.IgnoreCollision(gameObject.GetComponent<Collider2D>(),collision.collider);
        }
    }
}
