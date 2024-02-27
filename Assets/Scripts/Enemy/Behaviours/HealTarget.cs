using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealTarget : MonoBehaviour
{
    private Transform target;
    private float healAmt;

    public void SetTarget(Transform target, float healAmt){
        this.target = target;
        this.healAmt = healAmt;
    }


    private void OnTriggerEnter2D(Collider2D other) {
        if(other.gameObject == target.gameObject){
            Destroy(gameObject);
            target.gameObject.GetComponent<EnemyHpManager>().Heal(healAmt);
        }
    }
}
