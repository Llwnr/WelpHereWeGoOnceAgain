using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MultiShoot : Relic
{
    public int extraShots{get; private set;} = 0;
    public float dmgMultiplier{get; private set;} = 0;

    //Functions for upgrading variables
    public void IncreaseDmgMultiplierBy(float amt){
        dmgMultiplier += amt;
    }

    public void IncreaseNumOfExtraBulletsBy(int amt){
        extraShots += amt;
    }
}
