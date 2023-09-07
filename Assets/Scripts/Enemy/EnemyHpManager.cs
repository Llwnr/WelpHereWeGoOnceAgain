using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHpManager : MonoBehaviour, IDamagable
{
    [SerializeField]private float maxHp;

    public void DealDamage(float dmgAmt){
        maxHp -= dmgAmt;
        if(maxHp <= 0){
            Destroy(gameObject);
        }
    }
}
