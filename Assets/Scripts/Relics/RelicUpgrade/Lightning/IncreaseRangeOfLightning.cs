using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IncreaseRangeOfLightning : RelicSkill
{
    [SerializeField]private Vector2 extraRange;
    public override void Upgrade()
    {
        relicManager.GetComponent<Lightning>().IncreaseRange(extraRange);
    }
}
