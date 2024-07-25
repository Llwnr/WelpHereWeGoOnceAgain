using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lightning : Relic
{
    public float lightningDuration{get; private set;} = 0.5f;
    public float dmgMultiplier{get; private set;} = 1;
    public int numOfLightningStrikes{get; private set;} = 1;
    public Vector2 lightningFieldRange{get; private set;} = new Vector2(1,1);

    public void IncreaseDuration(float amt){
        lightningDuration += amt;
    }

    public void IncreaseDmgMultiplier(float amt){
        dmgMultiplier += amt;
    }

    public void IncreaseLightningStrikes(int amt){
        numOfLightningStrikes += amt;
    }

    public void IncreaseRange(Vector2 amt){
        lightningFieldRange += amt;
    }
}
