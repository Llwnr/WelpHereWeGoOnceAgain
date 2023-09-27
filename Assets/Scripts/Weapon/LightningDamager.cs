using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightningDamager : MonoBehaviour
{
    [SerializeField]private float dmgAmt;
    private float dmgMultiplier = 1;

    private void OnTriggerEnter2D(Collider2D other) {
        if(other.transform.CompareTag("Enemy")){
            other.GetComponent<IDamagable>().DealDamage(dmgAmt*dmgMultiplier, other.ClosestPoint(transform.position));
        }
    }
}
