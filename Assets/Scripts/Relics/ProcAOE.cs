using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProcAOE : ShotCounterBasedRelic
{
    public override void OnAttack(){
        base.OnAttack();
    }

    public override void ActivateSkill(){
        Debug.Log("procced at shot: " + bulletShot);
        StartCoroutine(MultiShot(2));
    }

    IEnumerator MultiShot(int numOfShots){
        yield return new WaitForSeconds(0.03f);
        WeaponManager.instance.ActivateWeapon();
        if(numOfShots > 0){
            StartCoroutine(MultiShot(--numOfShots));
        }
    }
}
