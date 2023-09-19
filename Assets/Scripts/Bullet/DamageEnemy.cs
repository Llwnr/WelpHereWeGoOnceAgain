using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageEnemy : MonoBehaviour
{
    [SerializeField]private float myDmg = 0;
    private float dmgMultiplier = 1;
    private float playerAtkStat = 0;

    //For bullet to hit only one time
    private bool alreadyUsed = false;

    public void SetPlayerAtkStat(float statAmt){
        playerAtkStat = statAmt;
    }

    public void SetDmgMultiplier(float amt){
        dmgMultiplier = amt;
    }

    private void OnTriggerEnter2D(Collider2D other) {
        if(other.transform.CompareTag("Enemy") && !alreadyUsed){
            other.GetComponent<IDamagable>().DealDamage(CalculateDamage());
            alreadyUsed = true;
            Destroy(gameObject);
        }
    }

    float CalculateDamage(){
        float finalDmg;
        finalDmg = (myDmg+myDmg*0.01f*playerAtkStat)*dmgMultiplier;
        return finalDmg;
    }
}
