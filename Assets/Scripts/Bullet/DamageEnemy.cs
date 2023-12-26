using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(BulletStats))]
public class DamageEnemy : MonoBehaviour
{
    [SerializeField]private float myDmg = 0;
    private float dmgMultiplier = 1;
    private float playerAtkStat = 0;

    //For bullet to hit only one time
    private bool alreadyUsed = false;

    private BulletStats bulletStats;

    private void OnEnable() {
        bulletStats = GetComponent<BulletStats>();
    }

    public void SetPlayerAtkStat(float statAmt){
        playerAtkStat = statAmt;
    }

    public void SetDmgMultiplier(float amt){
        dmgMultiplier = amt;
    }

    private void OnTriggerEnter2D(Collider2D other) {
        if(other.transform.CompareTag("Enemy") && !alreadyUsed){
            other.GetComponent<IDamagable>().DealDamage(CalculateDamage(), other.ClosestPoint(transform.position));

            bulletStats.ReducePierceOnHit();
            //Only destroy the bullet when its piercing power ends
            if(bulletStats.pierceAmt <= 0){
                alreadyUsed = true;
                Destroy(gameObject);
            }
        }
    }

    float CalculateDamage(){
        float finalDmg;
        //Debug.Log("Player atk: " + playerAtkStat);
        finalDmg = (myDmg+myDmg*0.1f*playerAtkStat)*dmgMultiplier;
        return finalDmg;
    }
}
