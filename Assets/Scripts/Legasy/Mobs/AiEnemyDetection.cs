using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AiEnemyDetection : MonoBehaviour
{
    MobController mc;
    void Start()
    {
        mc = GetComponentInParent<MobController>();
    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        if (gameObject.CompareTag("Enemy") && col.CompareTag("Friend") || col.CompareTag("Player"))
        {
           // mc.ChangeCurrState(new MobMoveToTargetState(col.gameObject));

        }
        else if(gameObject.CompareTag("Friend") && col.CompareTag("Enemy"))
        {
          //  mc.ChangeCurrState(new MobMoveToTargetState(col.gameObject));
        }
    }


}
