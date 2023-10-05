using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class M_NarrowAngle : RelicSkill
{
    public override void Upgrade()
    {
        relicManager.GetComponent<MultiShoot>().NarrowAngle();
    }
}
