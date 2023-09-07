using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthManager : MonoBehaviour, IDamagable
{
    private PlayerBasicStats playerStats;
    private int currHp;

    private void Start() {
        playerStats = GetComponent<PlayerBasicStats>();
        currHp = playerStats.GetMaxHp();
    }

    public void DealDamage(float dmgAmt){
        currHp -= (int)dmgAmt;

        if(currHp <= 0){
            Destroy(gameObject);
        }
    }
}
