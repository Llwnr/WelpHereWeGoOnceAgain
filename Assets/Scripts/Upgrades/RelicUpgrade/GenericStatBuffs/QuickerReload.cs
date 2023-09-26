using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuickerReload : RelicSkill
{
    [Header ("In Percentage")]
    [SerializeField]private float reloadTimeReduc;

    public override void Upgrade(){
        WeaponManager.instance.DecreaseReloadTimeBy(reloadTimeReduc/100f);
    }
}
