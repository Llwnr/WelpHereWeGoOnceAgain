using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class L_ExtraLightningStrike : RelicSkill
{
    [SerializeField]private int extraStrikes;
    public override void Upgrade()
    {
        relicManager.GetComponent<Lightning>().IncreaseLightningStrikes(extraStrikes);
    }
}
