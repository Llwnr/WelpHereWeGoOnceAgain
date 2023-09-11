using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProcAOE : ShotCounterBasedRelic
{
    [SerializeField]private int numOfExtraShots;
    private int numOfUpgradedExtraShots = 0;
    public override void OnAttack(){
        base.OnAttack();
    }

    public override void ActivateSkill(){
        Debug.Log("procced at shot: " + bulletShot);
        StartCoroutine(MultiShot(numOfExtraShots+numOfUpgradedExtraShots));
    }

    IEnumerator MultiShot(int numOfShots){
        yield return new WaitForSeconds(0.03f);
        WeaponManager.instance.ActivateWeapon();
        if(numOfShots > 0){
            StartCoroutine(MultiShot(--numOfShots));
        }
    }
}
