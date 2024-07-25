using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightningDamager : MonoBehaviour
{
    [SerializeField]private float dmgAmt;
    private float dmgMultiplier = 1;
    private float playerAtkStats = 1;
    [SerializeField]private float dmgInterval = 0.5f;
    private float dmgIntervalCounter;
    private bool dealDmg = false;

    public void SetDmgMultiplier(float amt){
        dmgMultiplier = amt;
    }

    private void Start() {
        dmgIntervalCounter = dmgInterval;
    }

    private void Update() {
        dmgIntervalCounter -= Time.fixedDeltaTime;
        if(dmgIntervalCounter <= 0){
            dealDmg = true;
            dmgIntervalCounter = dmgInterval;
        }
        else{
            dealDmg = false;
        }
    }

    private void OnTriggerEnter2D(Collider2D other) {
        if(other.transform.CompareTag("Enemy")){
            DamageTarget(other);
        }
    }

    private void OnTriggerStay2D(Collider2D other) {
        if(dealDmg && other.transform.CompareTag("Enemy")){
            DamageTarget(other);
        }
    }

    public void DamageTarget(Collider2D target){
        //Get atk power of player+gun power
        playerAtkStats = WeaponManager.instance.GetPlayerAndWeaponAtk();
        target.GetComponent<IDamagable>().DealDamage((dmgAmt+playerAtkStats)*dmgMultiplier, transform.position+target.transform.position);
    }
}
