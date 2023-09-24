using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

public class MultiBurst : ShotCounterBasedRelicSkill
{
    [SerializeField]private int numOfExtraShots;
    private int numOfUpgradedExtraShots = 0;
    [SerializeField]private GameObject bullet;
    private float dmgMultiplier = 1;

    public override void OnAttack(){
        base.OnAttack();
    }

    // public override void ActivateSkill(){
    //     Debug.Log("procced at shot: " + activateOnShot);
    //     StartCoroutine(MultiShot(numOfExtraShots+numOfUpgradedExtraShots));
    // }

    // IEnumerator MultiShot(int numOfShots){
    //     yield return new WaitForSeconds(0.1f);
    //     //Spread shot like shotgun
    //     float angle = 0;
    //     for(int i=0; i<numOfShots; i++){
    //         int iDivisor = numOfShots/2;
    //         angle = (i-iDivisor)*15;
    //         weaponManager.ActivateWeapon(angle, bullet, dmgMultiplier);
    //     }
    // }

    //For upgradables
    public void IncreaseDmgMultiplierBy(float amt){
        dmgMultiplier += amt;
    }

    public override void Upgrade()
    {
        relicManager.AddComponent<MultiBurst>();
    }

    protected override void ActivateSkill()
    {
        
    }
}
