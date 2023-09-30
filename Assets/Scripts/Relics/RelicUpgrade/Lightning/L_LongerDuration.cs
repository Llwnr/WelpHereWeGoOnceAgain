using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class L_LongerDuration : RelicSkill
{
    [SerializeField]private float extraDuration;
    public override void Upgrade()
    {
        relicManager.GetComponent<Lightning>().IncreaseDuration(extraDuration);
    }
}
