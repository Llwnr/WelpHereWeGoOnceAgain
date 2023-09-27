using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BombRangePlus : RelicSkill
{
    [SerializeField]private float increaseRangeBy;
    [SerializeField]private Bomber.BombType bombType;
    public override void Upgrade()
    {
        relicManager.GetComponent<Bomber>().IncreaseExplosionRange(bombType, increaseRangeBy);
    }
}
