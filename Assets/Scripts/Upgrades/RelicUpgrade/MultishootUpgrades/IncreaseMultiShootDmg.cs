using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IncreaseMultiShootDmg : RelicUpgrader
{
    [SerializeField]private float increaseBy;
    public override void Upgrade()
    {
        relicManager.GetComponent<MultiBurst>().IncreaseDmgMultiplierBy(increaseBy);
    }
}
