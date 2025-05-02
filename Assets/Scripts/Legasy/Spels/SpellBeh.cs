using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public abstract class SpellBeh : MonoBehaviour
{
    [SerializeField] protected float spellCost = 1;
    public float SpellCastDelay = 1f;
    protected bool castDelay = false;

    protected Button spellButton;
    protected ManaBeh pMana;
    public float SpellCost
    {
        get => spellCost;
        set => spellCost = value;
    }

    public abstract void CastSpell();

    protected IEnumerator spellCastDelayTimer()
    {
        float timer = 0f;
        
        while(timer < SpellCastDelay)
        {
            timer += 0.1f;
            yield return new WaitForSeconds(0.1f);
        }
        castDelay = false;
        if(spellButton != null)
        {
            spellButton.interactable = true;
        }
        
    }

    public virtual void ButtonOff(GameObject button)
    {
        if (pMana.canCast)
        {
            Debug.Log("мана=" + pMana.mana + " стоимость заклинания=" + spellCost);
            button.GetComponent<Button>().interactable = false;
            spellButton = button.GetComponent<Button>();
        }
            

    }

  
}
