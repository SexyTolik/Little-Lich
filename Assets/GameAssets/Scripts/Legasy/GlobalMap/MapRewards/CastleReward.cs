using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CastleReward : MapReward
{
    public override void GiveReward()
    {
        ProgressController.instance.CompanyInProgress = false;
    }
}
