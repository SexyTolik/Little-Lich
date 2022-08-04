using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileCastSpels : SpellBeh
{
    public GameObject Projectile;
    public float ProjtileSpeed = 10;

    private IDirection dir;
    private void Start()
    {
        dir = GetComponentInParent<IDirection>();
        pMana = GetComponentInParent<ManaBeh>();
    }

    public override void CastSpell()
    {
        if (!castDelay)
        {
            if (pMana.TakeMana(spellCost))
            {
                castDelay = true;
                GameObject proj = Instantiate(Projectile, transform.position, transform.rotation);
                proj.transform.right = dir.lastDir;
                proj.GetComponent<Rigidbody2D>().velocity = dir.lastDir.normalized * ProjtileSpeed;
                StartCoroutine(spellCastDelayTimer());
            }
        }

    }
}
