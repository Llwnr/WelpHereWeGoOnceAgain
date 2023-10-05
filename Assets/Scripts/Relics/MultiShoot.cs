using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MultiShoot : Relic
{
    public int extraShots{get; private set;} = 0;
    public float dmgMultiplier{get; private set;} = 0;
    public int extraPiercePower{get; private set;} = 0;
    public float spreadAngle{get; private set;} = 15;

    //Functions for upgrading variables
    public void IncreaseDmgMultiplierBy(float amt){
        dmgMultiplier += amt;
    }

    public void IncreaseNumOfExtraBulletsBy(int amt){
        extraShots += amt;
    }

    public void IncreasePiercePower(){
        extraPiercePower++;
    }

    public void NarrowAngle(){
        spreadAngle = 4;
    }
}
