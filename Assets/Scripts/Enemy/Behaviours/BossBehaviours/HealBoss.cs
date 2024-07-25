using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealBoss : MonoBehaviour
{
    private Transform boss;
    private EnemyHpManager hpManager;

    public GameObject healPotion;

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
            SendHeal();
        }
        if(!boss) Destroy(gameObject);
    }

    void SendHeal(){
        //Specify the target to provide the heals
        GameObject myHealPotion = Instantiate(healPotion, transform.position, Quaternion.identity);
        MoveToTarget healPotionMovement = myHealPotion.GetComponent<MoveToTarget>();
        HealTarget potionTarget = myHealPotion.GetComponent<HealTarget>();
        //Set the target to follow and heal
        healPotionMovement.SetTarget(boss);
        potionTarget.SetTarget(boss, healAmt);
    }


    void ResetCooldown(){
        cooldownCounter = healCooldown;
    }
}
