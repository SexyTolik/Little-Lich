using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    private IDirection Dir;
    private Rigidbody2D rb;
    [SerializeField] private float _spead = 3;
    public float Speed
    {
        get => _spead;
        set => _spead = Mathf.Clamp(value, 1, 50);
    }    
    
    void Start()
    {
        Dir = GetComponent<IDirection>();
        rb = GetComponent<Rigidbody2D>();
    }

    private void FixedUpdate()
    {
        if (Dir.GetCurrDirection() != Vector2.zero)
        {
            rb.MovePosition(rb.position + Dir.lastDir * Speed * Time.fixedDeltaTime);
        }
    }

}
