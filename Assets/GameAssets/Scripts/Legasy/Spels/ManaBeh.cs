using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ManaBeh : MonoBehaviour
{
    public float MaxMana;
    public float mana;
    public float ManaRegenInSec = 1;

    Coroutine manaReg;
    bool manaRegIsActive = false;
    public bool canCast = true;

    private void Start()
    {
        mana = MaxMana;
    }
    public bool TakeMana(float spellcost)
    {
        if (spellcost > mana)
        {
            Debug.Log(gameObject.name + " не хватает маны. “екуща€ мана = "+ mana + " а требуетс€ " + spellcost);
            canCast = false;
            return false;
        }
        else
        {
            mana -= spellcost;
            canCast = true;
            if (!manaRegIsActive)
            {
                manaRegIsActive = true;
                manaReg = StartCoroutine(ManaRegen());
            }
            return true;
        }
    }
    IEnumerator ManaRegen()
    {
       while(mana < MaxMana)
       {
            mana += ManaRegenInSec;
            yield return new WaitForSeconds(1f);
       }

       if(mana > MaxMana)
       {
            mana = MaxMana;
       }
        manaRegIsActive = false;
    }
}
