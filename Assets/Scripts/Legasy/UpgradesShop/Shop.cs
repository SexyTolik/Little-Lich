using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shop : MonoBehaviour
{
    [SerializeField]
    public List<(string, int)> NameAndLevelList = new List<(string, int)>();
    public PreviewWindow Pwindow;
    public Money MoneyContainer;


    private void Awake()
    {
            if(GlobalMapSaver.instance.LoadSavedUpgrades() == null || GlobalMapSaver.instance.save.PastTime == 0f)
            {
                GlobalMapSaver.instance.save.UpgradesData.Clear();
                GlobalMapSaver.instance.SaveUpgrades(NameAndLevelList);
            }
            else
            {
                NameAndLevelList = GlobalMapSaver.instance.LoadSavedUpgrades();
            }
            MoneyContainer.MoneyCount = GlobalMapSaver.instance.save.Money;
    }

}
