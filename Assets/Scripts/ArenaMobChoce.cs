using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ArenaMobChoce : MonoBehaviour
{
    public NpcSpawnSpell Slot1,Slot2;
    public NPCSpellsLoader IconLoader;

    public Image SlotIm1;
    public Image SlotIm2;

    private int Slot;

    public void ChoceSlot(int num)
    {
        Slot = num;
    }
    public void ChoceMob(string mobName)
    {
        Slot = Mathf.Clamp(Slot, 1, 2);
        mobName = mobName + "Data";
        if (Slot == 1)
        {
            Slot1.SelectMob(mobName);
            IconLoader.NPC1 = Resources.Load<MobData>("Mobs/" + mobName)._MobPrefab;
            IconLoader.SpellButton1.sprite = IconLoader.NPC1.GetComponent<MobController>().CurMob.SpellButton1;
            SlotIm1.sprite = IconLoader.NPC1.GetComponent<MobController>().CurMob.SpellButton1;
        }
        else
        {
            Slot2.SelectMob(mobName);
            IconLoader.NPC2 = Resources.Load<MobData>("Mobs/" + mobName)._MobPrefab;
            IconLoader.SpellButton1.sprite = IconLoader.NPC2.GetComponent<MobController>().CurMob.SpellButton2;
            SlotIm2.sprite = IconLoader.NPC2.GetComponent<MobController>().CurMob.SpellButton2;
        }
        IconLoader.SetIcons();
    }

    private void Start()
    {
        Slot = 1;
        ChoceMob("Zombie");
        Slot = 2;
        ChoceMob("Zombie");
    }

}
