using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoreAtkSpeed : RelicSkill
{
    [Header ("In Percentage")]
    [SerializeField]private float atkSpeedBuff;

    public override void Upgrade(){
        WeaponManager.instance.IncreaseAtkSpeedBy(atkSpeedBuff/100f);
    }
}
