using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExtraShots : RelicSkill
{
    [SerializeField]private int numOfExtraShots;
    public override void Upgrade()
    {
        relicManager.GetComponent<MultiShoot>().IncreaseNumOfExtraBulletsBy(numOfExtraShots);
    }
}
