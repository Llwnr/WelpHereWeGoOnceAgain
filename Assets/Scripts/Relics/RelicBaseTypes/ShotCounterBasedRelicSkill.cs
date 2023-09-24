using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//These skills will activate based on how many numbers of attack player has done
//For example: For every 5 bullets shot activate this skill
public abstract class ShotCounterBasedRelicSkill : RelicSkill, IOnAttack
{
    [Header ("Upgrade Properties")]
    //Activate this after a certain number of bullets are shot
    [SerializeField]protected int activateOnShot;
    protected int bulletShotCounter;
    protected GameObject player;

    public override void Upgrade(){
        bulletShotCounter = 0;
        player = GameObject.FindWithTag("Player");
        Debug.Log("Shotcounter is upgraded");
        //Subscribe to know how many bullets have been shot
        WeaponManager.instance.AddOnAttackListener(this);
    }

    private void OnDestroy(){
        WeaponManager.instance.RemoveOnAttackListener(this);
    }

    public virtual void OnAttack(){
        if(!isUnlocked) return;
        Debug.Log("pew pew");
        bulletShotCounter++;
        if(bulletShotCounter == activateOnShot){
            bulletShotCounter = 0;
            ActivateSkill();
            
        }
    }

    protected abstract void ActivateSkill();
}
