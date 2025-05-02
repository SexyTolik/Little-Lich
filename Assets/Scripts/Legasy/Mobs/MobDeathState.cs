using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MobDeathState : BaseMobState
{
    private MobController controller;
    private int layerOnDeath;

    public MobDeathState(MobController controller)
    {
        this.controller = controller;
    }

    public override void Entry()
    {
        if (controller.HaveSoul)
        {
            Debug.Log("enemy layer is = " + controller.gameObject.layer);
            controller.HaveSoul = false;
            controller.Aipath.IsMoving = false;
            controller.GetComponent<Animator>().SetTrigger("Death");
            controller.currWeaphon.gameObject.SetActive(false);
            layerOnDeath = controller.gameObject.layer;
            controller.gameObject.layer = LayerMask.NameToLayer("Corpce");
            controller.GetComponent<BadGuyCounter>().IamDead();
            controller.DelayMethod = controller.DesentigrateMobController;
            controller.StartCoroutine(controller.Timer(30f, controller.DelayMethod));
            MonoBehaviour.Instantiate(controller.DiedGhost, controller.transform.position,Quaternion.identity);
            PlayerValuesStorage.instance.MoneyValue++;
        }
        else
        {
            controller.DesentigrateMobController();
        }
    }

    public override void UpdateLogic()
    {
       
    }

    public override void Exit()
    {
        controller.gameObject.layer = layerOnDeath;
    }
}
