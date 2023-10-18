using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class L_MoreDmg : RelicSkill
{
    [Header ("In Percentage")]
    [SerializeField]private float extraMultiplier;
    public override void Upgrade()
    {
        relicManager.GetComponent<Lightning>().IncreaseDmgMultiplier(extraMultiplier/100f);
    }
}
