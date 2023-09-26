using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IncreaseMultiShootDmg : RelicSkill
{
    [SerializeField]private float increaseBy;
    public override void Upgrade()
    {
        relicManager.GetComponent<MultiShoot>().IncreaseDmgMultiplierBy(increaseBy);
    }
}
