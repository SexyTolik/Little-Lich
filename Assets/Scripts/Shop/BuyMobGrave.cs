using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BuyMobGrave : MonoBehaviour
{
    public MobData SelectedMob;
    public NPCSpellsLoader SpellLoader;
    public NpcSpawnSpell Spell1, Spell2;
    public Button UseButton;
    public GameObject MobCostImg;
    public int MobCost;
    [SerializeField]
    private bool isBought = false;
    public SpriteRenderer Graveimage;
    public GameObject BuyEffect;

    private PlayerValuesStorage playerValues;
    private bool Slot = true;
    private bool InTrigger = false;
    public bool IsBought
    {
        get => isBought;
        set
        {
            if(value)
            {
                isBought = true;
                Graveimage.sprite = SelectedMob.GraveBought;
            }
            else
            {
                isBought = false;
                Graveimage.sprite = SelectedMob.GraveUnbought;
            }
        }
    }
    private void Start()
    {
        playerValues = PlayerValuesStorage.instance;
        Graveimage= GetComponent<SpriteRenderer>();
        IsBought = IsBought;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player") && !InTrigger)
        {
            UseButton.gameObject.SetActive(true);
            UseButton.onClick.AddListener(BuyThisMob);
            Debug.Log("Вошел в тригер " + gameObject.name);
            InTrigger = true;
            if(!IsBought)
            {
                MobCostImg.SetActive(true);
            }
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            UseButton.gameObject.SetActive(false);
            MobCostImg.SetActive(false);
            UseButton.onClick.RemoveAllListeners();
            Debug.Log("Вышел тригера " + gameObject.name);
            InTrigger= false;
            MobCostImg.SetActive(false);
        }
    }

    public void BuyThisMob()
    {
        if(!IsBought)
        {
            if (PlayerValuesStorage.instance.TryBuy(MobCost))
            {
                IsBought= true;
                Instantiate(BuyEffect, gameObject.transform.position,Quaternion.identity);
                MobCostImg.SetActive(false);
            }
        }
        else
        {
            if(Slot)
            {
                Spell1.SelectMob(SelectedMob._MobName + "Data");
                SpellLoader.NPC1 = SelectedMob._MobPrefab;
            }
            else
            {
                Spell2.SelectMob(SelectedMob._MobName + "Data");
                SpellLoader.NPC2 = SelectedMob._MobPrefab;
            }
            Slot = !Slot;
            SpellLoader.SetIcons();
        }
    }
}
