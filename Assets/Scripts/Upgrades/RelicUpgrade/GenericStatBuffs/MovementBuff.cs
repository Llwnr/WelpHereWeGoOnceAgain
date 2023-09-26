using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementBuff : RelicSkill
{
    [SerializeField]private float buffAmtInPercent;
    public override void Upgrade(){
        PlayerBasicStats.instance.BuffMovementSpeedBy(buffAmtInPercent/100);
    }
}
