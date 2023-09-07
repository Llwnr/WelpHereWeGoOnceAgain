using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamagePlayer : MonoBehaviour
{
    [SerializeField]private int dmgAmt;
    
    private void OnCollisionEnter2D(Collision2D other) {
        if(other.transform.CompareTag("Player")){
            other.transform.GetComponent<IDamagable>().DealDamage(dmgAmt);
        }
    }
}
