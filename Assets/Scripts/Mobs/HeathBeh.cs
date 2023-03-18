using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HeathBeh : MonoBehaviour // Health неправильно написал, bruh
{
    public float MaxHealth;
    [SerializeField] private float health;
    private bool IsDead = false;
    public SpriteRenderer TargetGraphics;
    public float Health
    {
        get { return health; }
        set
        {
            if (!IsDead)
            {
                StartCoroutine(redBlink());
                if (value >= health)
                {
                    health -= value;
                    IsDead= true;
                    if(GetComponent<MobController>() != null)
                    {
                        GetComponent<MobController>().ChangeCurrState<MobDeathState>();
                    }
                    else
                    {
                        Destroy(gameObject);
                    }
                }
                else
                {
                    health -= value;
                }
            }
        }
    }

    public void AddHealth(float hp)
    {
        health += hp;
        if(health > MaxHealth) { health = MaxHealth; }
        if(health > 0) { IsDead = false; }
    }

    private void Start()
    {
        health = MaxHealth;
    }

    private IEnumerator redBlink()
    {
        TargetGraphics.color = Color.red;
        yield return new WaitForSeconds(0.18f);
        TargetGraphics.color = Color.white;
    }
}
