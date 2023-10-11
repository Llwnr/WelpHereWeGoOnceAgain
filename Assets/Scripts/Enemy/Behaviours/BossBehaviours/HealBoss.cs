using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealBoss : MonoBehaviour
{
    private Transform boss;
    private EnemyHpManager hpManager;

    [SerializeField]private float healCooldown;
    [SerializeField]private float healAmt;
    private float cooldownCounter;
    public void SetBossTarget(Transform target){
        boss = target;
        hpManager = boss.GetComponent<EnemyHpManager>();
    }

    private void Start() {
        ResetCooldown();
    }

    private void Update() {
        cooldownCounter -= Time.deltaTime;
        if(cooldownCounter <= 0){
            ResetCooldown();
            Heal();
        }
    }

    void Heal(){
        //Play heal animation
        hpManager.Heal(healAmt);
    }


    void ResetCooldown(){
        cooldownCounter = healCooldown;
    }
}
