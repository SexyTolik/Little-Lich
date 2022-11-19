using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NpcSpawnSpell : SpellBeh
{
    public GameObject NpcPrefab;
    public int behOrder = 1; // 1 or 2
    private string mobName;

    private CircleCollider2D nearArea;

  //  private bool canSpawn = true;

    void Start()
    {
        if(behOrder == 1) { mobName = GlobalMapSaver.instance.LoadSelectedMobs().Item1; } else { mobName = GlobalMapSaver.instance.LoadSelectedMobs().Item2; }
        NpcPrefab = Resources.Load<MobData>("Mobs/" + mobName)._MobPrefab;
        pMana = GetComponentInParent<ManaBeh>();
        nearArea = pMana.GetComponentInChildren<CircleCollider2D>();
        SpellCastDelay = NpcPrefab.GetComponent<MobController>().CurMob._CastDelay;
        spellCost = NpcPrefab.GetComponent<MobController>().CurMob._CastCost;
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
