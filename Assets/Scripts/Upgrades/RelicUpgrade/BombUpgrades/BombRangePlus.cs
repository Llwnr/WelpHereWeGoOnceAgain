using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BombRangePlus : RelicSkill
{
    [SerializeField]private float increaseRangeBy;
    public override void Upgrade()
    {
        relicManager.GetComponent<ThrowBombs>().IncreaseExplosionRange(increaseRangeBy);
    }
}
