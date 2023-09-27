using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamagePlayer : MonoBehaviour
{
    [SerializeField]private int dmgAmt;
    
    private void OnCollisionEnter2D(Collision2D other) {
        if(other.transform.CompareTag("Player")){
            other.transform.GetComponent<IDamagable>().DealDamage(dmgAmt, other.contacts[0].point);
        }
    }

    private void OnTriggerEnter2D(Collider2D other) {
        if(other.transform.CompareTag("Player")){
            other.transform.GetComponent<IDamagable>().DealDamage(dmgAmt, other.ClosestPoint(transform.position));

            //Destroy bullet when they collide with player
            if(transform.CompareTag("Bullet")){
                Destroy(gameObject);
            }
        }

        
    }
}
