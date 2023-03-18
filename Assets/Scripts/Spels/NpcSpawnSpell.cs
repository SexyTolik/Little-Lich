using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class NpcSpawnSpell : SpellBeh
{
    public GameObject NpcPrefab;
    public TextMeshPro TextCount;
    public int behOrder = 1; // 1 or 2
    public float CorpceGetUpRange = 3f;
    public int CorpceCost = 1;
    private string mobName;
    private bool canCast;

    private CircleCollider2D nearArea;
    public bool IsArena = false;

    public TextMeshProUGUI countText;
    void Start()
    {
        if (!IsArena)
        {
        if(behOrder == 1) { mobName = GlobalMapSaver.instance.LoadSelectedMobs().Item1; } else { mobName = GlobalMapSaver.instance.LoadSelectedMobs().Item2; }
           SelectMob(mobName);
        }
        pMana = GetComponentInParent<ManaBeh>();
        nearArea = pMana.GetComponentInChildren<CircleCollider2D>();
    }
    public override void CastSpell()
    {
        if (!castDelay && GoodGuyCounter.instance.TotalFriends < GoodGuyCounter.instance.MaxFriends)
        {
            List<Collider2D> corpseInRadius = new List<Collider2D>();
            ContactFilter2D filter = new ContactFilter2D();
            filter.SetLayerMask(LayerMask.GetMask("Corpce"));
            
            if (Physics2D.OverlapCircle(transform.position, CorpceGetUpRange, filter, corpseInRadius) >= CorpceCost && pMana.TakeMana(spellCost))
            {
                canCast= true;
                Vector3 corpcePos = new Vector3();
                for(int i = 0; i <= (CorpceCost-1); i++)
                {
                    GameObject corpce = corpseInRadius[i].gameObject;
                    corpcePos = corpce.transform.position;
                    Destroy(corpce);
                }
                castDelay = true;
                Instantiate(NpcPrefab, corpcePos, Quaternion.identity);
                StartCoroutine(spellCastDelayTimer());
            }
            else
            {
             //   spellButton.interactable = true;
            }

        }
        else
        {
          //  canSpawn = false;
        }
    }

    public override void ButtonOff(GameObject button)
    {
        if (GoodGuyCounter.instance.TotalFriends < GoodGuyCounter.instance.MaxFriends && canCast)
        {
            base.ButtonOff(button);
            canCast= false;
        }
    }
    
    public void SelectMob(string name)
    {
        NpcPrefab = Resources.Load<MobData>("Mobs/" + name)._MobPrefab;
        SpellCastDelay = NpcPrefab.GetComponent<MobController>().CurMob._CastDelay;
        spellCost = NpcPrefab.GetComponent<MobController>().CurMob._CastCost;
        CorpceCost = NpcPrefab.GetComponent<MobController>().CurMob._CorpceCost;
        //countText.text = "corpse to spawn:" + CorpceCost;
    }

    public void DetectCorpces()
    {
        List<Collider2D> corpseInRadius = new List<Collider2D>();
        ContactFilter2D filter = new ContactFilter2D();
        filter.SetLayerMask(LayerMask.GetMask("Corpce"));

        TextCount.text = $"{Physics2D.OverlapCircle(transform.position, CorpceGetUpRange, filter, corpseInRadius)} / {CorpceCost}";
    }

}
