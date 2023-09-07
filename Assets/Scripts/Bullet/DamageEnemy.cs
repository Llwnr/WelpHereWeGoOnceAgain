using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageEnemy : MonoBehaviour
{
    private float myDmg = 0;

    public void SetDmgAmt(float dmgAmt){
        myDmg = dmgAmt;
    }

    private void OnTriggerEnter2D(Collider2D other) {
        if(other.transform.CompareTag("Enemy")){
            other.GetComponent<IDamagable>().DealDamage(myDmg);
            Destroy(gameObject);
        }
    }
}
