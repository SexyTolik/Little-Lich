using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RangeWeapon : Iweapon
{
    public GameObject Projectile;
    public float ProjtileSpeed = 10;
    private float DeleyToSpawnProjectile = 1f;
    private IDirection dir;

    void Start()
    {
        dir = GetComponentInParent<IDirection>();
//        Projectile = GetComponent<SimpleArrow>();
//        Projectile = resources.load();
    }

    public override void Attack()
    {
        if (!IsAttacking)
        {
            IsAttacking = true;
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
        GameObject proj = Instantiate(Projectile, transform.position, transform.rotation);
        proj.transform.right = dir.lastDir;
        proj.GetComponent<Rigidbody2D>().velocity = dir.lastDir.normalized * ProjtileSpeed;
        IsAttacking = false;
    }
}
