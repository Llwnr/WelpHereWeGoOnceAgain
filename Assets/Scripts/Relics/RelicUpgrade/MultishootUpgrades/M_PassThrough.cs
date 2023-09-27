using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class M_PassThrough : RelicSkill
{
    public override void Upgrade()
    {
        relicManager.GetComponent<MultiShoot>().IncreasePiercePower();
    }
}
