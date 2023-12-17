using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightningDamager : MonoBehaviour
{
    [SerializeField]private float dmgAmt;
    private float dmgMultiplier = 1;
    private float playerAtkStats = 1;

    public void SetDmgMultiplier(float amt){
        dmgMultiplier = amt;
    }

    private void OnTriggerEnter2D(Collider2D other) {
        if(other.transform.CompareTag("Enemy")){
            DamageTarget(other);
        }
    }

    public void DamageTarget(Collider2D target){
        //Get atk power of player+gun power
        playerAtkStats = (WeaponManager.instance.GetPlayerAndWeaponAtk()*0.1f);
        target.GetComponent<IDamagable>().DealDamage(dmgAmt*dmgMultiplier + playerAtkStats*dmgAmt, target.ClosestPoint(transform.position));
    }
}
