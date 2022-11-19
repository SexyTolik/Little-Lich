using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NPCSpellsLoader : MonoBehaviour
{
    private GameObject NPC1;
    private GameObject NPC2;

    public Image SpellButton1; // кнопки 1 и 2
    public Image SpellButton2;

    void Start()
    {
        string mobName1 = GlobalMapSaver.instance.LoadSelectedMobs().Item1;
        string mobName2 = GlobalMapSaver.instance.LoadSelectedMobs().Item2;
        NPC1 = Resources.Load<MobData>("Mobs/" + mobName1)._MobPrefab;
        NPC2 = Resources.Load<MobData>("Mobs/" + mobName2)._MobPrefab;

        SpellButton1.sprite = NPC1.GetComponent<MobController>().CurMob.SpellButton1;
        SpellButton2.sprite = NPC2.GetComponent<MobController>().CurMob.SpellButton2;
    }
}
