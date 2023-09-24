using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FasterShootAndReload : RelicSkill
{
    [Header ("In Percentage")]
    [SerializeField]private float atkSpeedBuff, reloadTimeReduc;

    public override void Upgrade(){
        WeaponManager.instance.IncreaseAtkSpeedBy(atkSpeedBuff/100f);
        WeaponManager.instance.DecreaseReloadTimeBy(reloadTimeReduc/100f);
    }
}
