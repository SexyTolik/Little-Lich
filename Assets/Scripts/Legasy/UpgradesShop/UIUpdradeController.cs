using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIUpdradeController : MonoBehaviour
{
    public MobData MData;
    public Sprite PreviewImage;
    public bool purchaced = false;
    private Shop shop;

    public double BuyCost;
    public double BaseUpgradeCost;
    public double upgradeCost;

    private void Start()
    {
        upgradeCost = BaseUpgradeCost;
        shop = GetComponentInParent<Shop>();
        (string, int) NameAndLvl = (MData._MobName, MData._MobLevel);
            if (shop.NameAndLevelList.Count == 0 && purchaced)
            {
                shop.NameAndLevelList.Add(NameAndLvl);
                UpdateUpgradeCost();
                GlobalMapSaver.instance.SaveUpgrades(shop.NameAndLevelList);
                return;
            }
            foreach(var NaL in shop.NameAndLevelList)
            {
                if(NaL.Item1 == MData._MobName)
                {
                    purchaced = true;
                    MData._MobLevel = NaL.Item2;
                    UpdateUpgradeCost();
                    return;
                }
            }
    }
    public void ShowThisMob()
    {
        if (purchaced)
        {
            if(MData._MobLevel == 3)
            {
                shop.Pwindow.CostText.text = "MaxLvL";
            }
            else
            {
                shop.Pwindow.CostText.text = upgradeCost.ToString();
                shop.Pwindow.UpgradeText.text = "Upgrade";
            }
            
        }
        else
        {
            shop.Pwindow.CostText.text = BuyCost.ToString();
            shop.Pwindow.UpgradeText.text = "Buy";
        }
        shop.Pwindow.PrePreviewImage.sprite = PreviewImage;
        shop.Pwindow.AttakSpeedStat.text = MData._AttakDelay.ToString();
        shop.Pwindow.AttakStat.text = MData._AttakDamage.ToString();
        shop.Pwindow.HpStat.text = MData._MaxHealth.ToString();
        shop.Pwindow.ManaCostStat.text = MData._CastCost.ToString();
        shop.Pwindow.SpeedStat.text = MData._Speed.ToString();
        shop.Pwindow.Desctp.text = MData._Description;
        if (MData._MobLevel > 0)
        {
            float UpgradeFactor = 1.2f + ((0.15f * MData._MobLevel) - 0.15f);
            shop.Pwindow.HpStat.text = (MData._MaxHealth * UpgradeFactor).ToString();
            shop.Pwindow.AttakStat.text = (MData._AttakDamage * UpgradeFactor).ToString();
        }
        shop.Pwindow.SelectedMob = this;
    }

    public void BuyThisMob()
    {
        if(shop.MoneyContainer.MoneyCount >= BuyCost)
        {
            shop.MoneyContainer.MoneyCount -= (int)BuyCost;
            purchaced = true;
            (string, int) NameAndLvl = (MData._MobName, MData._MobLevel);
            shop.NameAndLevelList.Add(NameAndLvl);
            GlobalMapSaver.instance.SaveUpgrades(shop.NameAndLevelList);
            ShowThisMob();
        }
        else
        {
            Debug.Log("Денег не достаточно");
        }
        Debug.Log("после покупки моба в шопе " + shop.NameAndLevelList.Count + " элементов");
    }

    public void UpgradeThisMob()
    {

        if (shop.MoneyContainer.MoneyCount >= BaseUpgradeCost)
        {
            /*int x = 0;
            foreach(var v in shop.NameAndLevelList)
            {
                if (v.Item1 == MData._MobName)
                {
                    shop.NameAndLevelList.RemoveAt(x);
                    (string, int) NameAndLvl = (MData._MobName, MData._MobLevel);
                    shop.NameAndLevelList.Add(NameAndLvl);
                    GlobalMapSaver.instance.SaveUpgrades(shop.NameAndLevelList);
                    UpdateUpgradeCost();
                    ShowThisMob();
                    return;
                }
                x++;
            }
            */
            if(shop.NameAndLevelList.Contains((MData._MobName, MData._MobLevel)))
            {
                shop.NameAndLevelList.Sort();
                shop.NameAndLevelList.RemoveAt(shop.NameAndLevelList.BinarySearch((MData._MobName, MData._MobLevel)));
                GlobalMapSaver.instance.save.UpgradesData.Clear();
                shop.MoneyContainer.MoneyCount -= (int)BaseUpgradeCost;
                MData._MobLevel++;
                (string, int) NameAndLvl = (MData._MobName, MData._MobLevel);
                shop.NameAndLevelList.Add(NameAndLvl);
                GlobalMapSaver.instance.SaveUpgrades(shop.NameAndLevelList);
                UpdateUpgradeCost();
                ShowThisMob();
                return;
            }
            else
            {
                Debug.Log("Произошло что то страшное и мы каким то образом пытаемся заапгрейдить юнита которого не купили");
            }
        }
        else
        {
            Debug.Log("Денег не достаточно");
        }
        Debug.Log("после улучшения в шопе " + shop.NameAndLevelList.Count + " элементов");
    }

    public void UpdateUpgradeCost()
    {
        upgradeCost = BaseUpgradeCost + (MData._MobLevel * BaseUpgradeCost);
    }
}
