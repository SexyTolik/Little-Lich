using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RangeWeapon : Iweapon
{
    public GameObject Projectile;
    public float ProjtileSpeed = 6;
    private float DeleyToSpawnProjectile = 1f;
    private IDirection dir;
    private MobController controller;
    private float ProjectileAnimationDeley = 1f;
    public RangeAttackZone attakZone;
    // private SpriteRenderer spriteRenderer; 

    void Start()
    {
        dir = GetComponentInParent<IDirection>();
        controller = GetComponentInParent<MobController>();
        // spriteRenderer = gameObject.GetComponent<SpriteRenderer>();
    }

    public override void Attack() 
    {
        if (!IsAttacking)
        {
            IsAttacking = true;
            attakZone.CheckColls();
            StartCoroutine(SpawnProjectileDelay());
        }        
    }
    public IEnumerator SpawnProjectileDelay()
    {
        float currDelay = DeleyToSpawnProjectile;
        while (currDelay > 0)
        {
            currDelay -= 0.01f;
            yield return new WaitForSeconds(0.01f);
        }
        IsAttacking = false;
    }
}
