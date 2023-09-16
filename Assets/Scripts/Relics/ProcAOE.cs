using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProcAOE : ShotCounterBasedRelic
{
    [SerializeField]private int numOfExtraShots;
    private int numOfUpgradedExtraShots = 0;
    [SerializeField]private float shootInterval;
    public override void OnAttack(){
        base.OnAttack();
    }

    public override void ActivateSkill(){
        Debug.Log("procced at shot: " + bulletShot);
        StartCoroutine(MultiShot(numOfExtraShots+numOfUpgradedExtraShots));
    }

    IEnumerator MultiShot(int numOfShots){
        yield return new WaitForSeconds(shootInterval);
        float angle;
        if(numOfShots%2==0){
            angle = numOfShots*2;
        }else{
            angle = -numOfShots*2;
        }
        WeaponManager.instance.ActivateWeapon(angle);
        if(numOfShots > 0){
            StartCoroutine(MultiShot(--numOfShots));
        }
    }
}
