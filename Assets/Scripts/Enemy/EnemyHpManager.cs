using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHpManager : MonoBehaviour, IDamagable
{
    [SerializeField]private float maxHp;

    public void DealDamage(float dmgAmt){
        maxHp -= dmgAmt;
        Debug.Log("Damaged by: " + dmgAmt);
        if(maxHp <= 0){
            Destroy(gameObject);
        }
    }
}
