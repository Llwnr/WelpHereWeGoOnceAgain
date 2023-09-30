using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuickerReload : RelicSkill
{
    [Header ("In Percentage")]
    [SerializeField]private float reloadSpeedBuff;

    public override void Upgrade(){
        WeaponManager.instance.IncreaseReloadSpeedBy(reloadSpeedBuff/100f);
    }
}
