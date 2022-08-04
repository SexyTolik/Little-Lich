using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NpcSpawnSpell : SpellBeh
{
    public GameObject NpcPrefab;

    private CircleCollider2D nearArea;

  //  private bool canSpawn = true;

    void Start()
    {
        pMana = GetComponentInParent<ManaBeh>();
        nearArea = pMana.GetComponentInChildren<CircleCollider2D>();
    }
    public override void CastSpell()
    {
        if (!castDelay && GoodGuyCounter.instance.TotalFriends < GoodGuyCounter.instance.MaxFriends)
        {
            if (pMana.TakeMana(spellCost))
            {
             //   canSpawn = true;
                castDelay = true;
                Instantiate(NpcPrefab, transform.position, Quaternion.identity);
                StartCoroutine(spellCastDelayTimer());
            }
        }
        else
        {
          //  canSpawn = false;
        }
    }

    public override void ButtonOff(GameObject button)
    {
        if (GoodGuyCounter.instance.TotalFriends < GoodGuyCounter.instance.MaxFriends)
        {
            base.ButtonOff(button);
        }
    } 

}
