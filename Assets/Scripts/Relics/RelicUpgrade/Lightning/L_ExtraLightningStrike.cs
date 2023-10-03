using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class L_ExtraLightningStrike : RelicSkill
{
    public override void Upgrade()
    {
        relicManager.GetComponent<Lightning>().IncreaseLightningStrikes();
    }
}
