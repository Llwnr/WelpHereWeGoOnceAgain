using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//These skills will activate based on how many numbers of attack player has done
//For example: For every 5 bullets shot activate this skill
public abstract class ShotCounterBasedRelic : SubRelic
{
    [SerializeField]protected int bulletShot, bulletShotCounter;

    //Start() is replaced with OnStart()
    protected override void OnStart(){
        bulletShotCounter = 0;
    }

    public override void OnAttack(){
        bulletShotCounter++;
        if(bulletShotCounter == bulletShot){
            bulletShotCounter = 0;
            ActivateSkill();
        }
    }
}
