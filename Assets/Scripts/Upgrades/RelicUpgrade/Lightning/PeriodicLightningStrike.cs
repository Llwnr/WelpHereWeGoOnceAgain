using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PeriodicLightningStrike : TimerBasedRelicSkill
{
    public override void ActivateSkill()
    {
        Debug.Log("Lightning activated");
    }

    public override void Upgrade()
    {
        base.Upgrade();
    }
}
