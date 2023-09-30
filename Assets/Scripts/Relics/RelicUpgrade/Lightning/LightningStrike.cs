using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class LightningStrike : TimerBasedRelicSkill
{
    [SerializeField]private GameObject lightning;
    private float dmgMultiplier;
    private float duration;

    
    public override void ActivateSkill()
    {
        //Get info about lightning such as duration, dmg power etc
        GetLightningStats();

        GameObject newLightning = Instantiate(lightning, GameObject.FindWithTag("Player").transform.position + new Vector3(0,0,1), Quaternion.identity);
        newLightning.GetComponent<LightningDamager>().SetDmgMultiplier(dmgMultiplier);


        //Strike the closest enemy with lightning
        Collider2D[] enemies = Physics2D.OverlapCircleAll(GameObject.FindWithTag("Player").transform.position, 3);
        foreach(Collider2D enemy in enemies){
            if(enemy.CompareTag("Enemy")){
                Debug.Log("Enemy found");
                newLightning.GetComponent<GenerateLightningLine>().SetTargetPos(enemy.transform.position);
                //Also deal damage to that enemy
                newLightning.GetComponent<LightningDamager>().DamageTarget(enemy);
                return;
            }
        }
        
    }

    void GetLightningStats(){
        Lightning lightningStats = relicManager.GetComponent<Lightning>();
        dmgMultiplier = lightningStats.dmgMultiplier;
        duration = lightningStats.lightningDuration;
    }

    public override void Upgrade()
    {
        base.Upgrade();
    }
}
