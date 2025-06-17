using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class PreviewWindow : MonoBehaviour
{
    public Image PrePreviewImage;
    public TextMeshProUGUI CostText;
    public TextMeshProUGUI UpgradeText;
    public TextMeshProUGUI HpStat;
    public TextMeshProUGUI AttakStat;
    public TextMeshProUGUI AttakSpeedStat;
    public TextMeshProUGUI SpeedStat;
    public TextMeshProUGUI ManaCostStat;
    public TextMeshProUGUI Desctp;

    public UIUpdradeController SelectedMob;
    public Image SpellButton1;
    public Image SpellButton2;



    private void Start()
    {
        string mobName1 = GlobalMapSaver.instance.LoadSelectedMobs().Item1;
        string mobName2 = GlobalMapSaver.instance.LoadSelectedMobs().Item2;

        SpellButton1.sprite = Resources.Load<MobData>("Mobs/" + mobName1).SpellButton1;
        SpellButton2.sprite = Resources.Load<MobData>("Mobs/" + mobName2).SpellButton2;

        if (SelectedMob.purchaced)
        {
            SelectedMob.UpdateUpgradeCost();
            if (SelectedMob.MData._MobLevel == 3)
            {
                CostText.text = "MaxLvL";
            }
            else
            {
                CostText.text = SelectedMob.upgradeCost.ToString();
                UpgradeText.text = "Upgrade";
            }

        }
        else
        {
            CostText.text = SelectedMob.BuyCost.ToString();
            UpgradeText.text = "Buy";
        }
        PrePreviewImage.sprite = SelectedMob.PreviewImage;
        AttakSpeedStat.text = SelectedMob.MData._AttakDelay.ToString();
        AttakStat.text = SelectedMob.MData._AttakDamage.ToString();
        HpStat.text = SelectedMob.MData._MaxHealth.ToString();
        ManaCostStat.text = SelectedMob.MData._CastCost.ToString();
        SpeedStat.text = SelectedMob.MData._Speed.ToString();
        Desctp.text = SelectedMob.MData._Description;
        if (SelectedMob.MData._MobLevel > 0)
        {
            float UpgradeFactor = 1.2f + ((0.15f * SelectedMob.MData._MobLevel) - 0.15f);
            HpStat.text = (SelectedMob.MData._MaxHealth * UpgradeFactor).ToString();
            AttakStat.text = (SelectedMob.MData._AttakDamage * UpgradeFactor).ToString();
        }
    }

    public void BuyButton()
    {
        if (SelectedMob.purchaced)
        {
            SelectedMob.UpgradeThisMob();
        }
        else
        {
            SelectedMob.BuyThisMob();
        }
    }

    public void SetMobOnSpellSlot(int SlosNum)// должен быть равен 1 или 2
    {
        if (SelectedMob.purchaced)
        {
            (string, string) selMobs = GlobalMapSaver.instance.LoadSelectedMobs();
            switch (SlosNum)
            {
                case 1:
                    SpellButton1.sprite = SelectedMob.MData.SpellButton1;
                    selMobs.Item1 = SelectedMob.MData.name;
                    break;

                case 2:
                    SpellButton2.sprite = SelectedMob.MData.SpellButton2;
                    selMobs.Item2 = SelectedMob.MData.name;
                    break;

                default:
                    SpellButton1.sprite = SelectedMob.MData.SpellButton1;
                    selMobs.Item1 = SelectedMob.MData.name;
                    break;
            }
            GlobalMapSaver.instance.SaveSelectedMobs(selMobs);
        }
    }
}
