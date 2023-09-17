using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//These skills will activate based on how many numbers of attack player has done
//For example: For every 5 bullets shot activate this skill
public abstract class ShotCounterBasedRelic : SubRelic
{
    [Header ("Upgrade Properties")]
    //Activate this after a certain number of bullets are shot
    [SerializeField]protected int activateOnShot;
    protected int bulletShotCounter;

    //Start() is replaced with OnStart()
    protected override void OnStart(){
        bulletShotCounter = 0;
    }

    public override void OnAttack(){
        bulletShotCounter++;
        if(bulletShotCounter == activateOnShot){
            bulletShotCounter = 0;
            ActivateSkill();
        }
    }
}
