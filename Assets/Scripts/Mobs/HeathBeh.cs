using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeathBeh : MonoBehaviour // Health неправильно написал, bruh
{
    public float MaxHealth;
    [SerializeField] private float health;
    public float Health
    {
        get { return health; }
        set
        {
            if(value >= health)
            {
                health -= value;
                Debug.Log(gameObject.name +"  погиб беславной смертью с "+ Health + "хп");
                Destroy(gameObject);
            }
            else
            {
                health -= value;
            }
            
        }
    }

    public void AddHealth(float hp)
    {
        health += hp;
        if(health > MaxHealth) { health = MaxHealth; }
    }

    private void Start()
    {
        health = MaxHealth;
    }
}
