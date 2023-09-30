using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightningDamager : MonoBehaviour
{
    [SerializeField]private float dmgAmt;
    private float dmgMultiplier = 1;

    public void SetDmgMultiplier(float amt){
        dmgMultiplier = amt;
    }

    private void OnTriggerEnter2D(Collider2D other) {
        if(other.transform.CompareTag("Enemy")){
            DamageTarget(other);
        }
    }

    public void DamageTarget(Collider2D target){
        target.GetComponent<IDamagable>().DealDamage(dmgAmt*dmgMultiplier, target.ClosestPoint(transform.position));
    }
}
