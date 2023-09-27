using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KnockbackEnemyWhenDamaged : MonoBehaviour, IWhenDamaged
{
    [SerializeField]private float knockbackDuration, force;
    private void Start() {
        GetComponent<EnemyHpManager>().AddOnDamageListener(this);
    }
    
    public void WhenDamaged(float dmgAmt, Vector2 hitPoint)
    {
        Vector2 knockbackDir = (Vector2)transform.position - hitPoint;
        GetComponent<MoveTowardsPlayer>().SetExternalForceToActive(knockbackDuration);
        GetComponent<Rigidbody2D>().AddForce(knockbackDir*force, ForceMode2D.Impulse);
    }
}
