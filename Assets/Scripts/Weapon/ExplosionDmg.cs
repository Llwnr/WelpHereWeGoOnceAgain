using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExplosionDmg : MonoBehaviour, ISetDamageMultiplier
{
    [SerializeField]private float dmgAmt;
    private float dmgMultiplier = 1;

    public void SetDamageMultiplier(float dmgMultiplier)
    {
        this.dmgMultiplier = dmgMultiplier;
    }

    private void OnTriggerEnter2D(Collider2D other) {
        if(other.transform.CompareTag("Enemy")){
            other.GetComponent<IDamagable>().DealDamage(dmgAmt*dmgMultiplier);
        }
    }
}
