using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class LightningStrike : ShotCounterBasedRelicSkill
{
    [SerializeField]private GameObject lightning;
    [SerializeField]private float strikeRadius;
    private float dmgMultiplier;
    private int numOfLightningStrikes;
    
    protected override void ActivateSkill(){
        //Get info about lightning such as duration, dmg power etc
        GetLightningStats();

        //Strike the closest enemy with lightning
        Collider2D[] enemies = Physics2D.OverlapCircleAll(GameObject.FindWithTag("Player").transform.position, strikeRadius);
        foreach(Collider2D enemy in enemies){
            if(enemy.CompareTag("Enemy")){
                //Create Lightning;
                CreateLightningStrikeTo(enemy);
                //Only stop generating lightning when the limit for num of lightning strike is reached
                numOfLightningStrikes--;
                if(numOfLightningStrikes <= 0){
                    return;
                }
            }
        }
        
    }

    //Generates lightning strike to hit the target
    void CreateLightningStrikeTo(Collider2D target){
        GameObject newLightning = Instantiate(lightning, GameObject.FindWithTag("Player").transform.position + new Vector3(0,0,-1), Quaternion.identity);
        newLightning.transform.eulerAngles = lightning.transform.eulerAngles;
        newLightning.GetComponent<LightningDamager>().SetDmgMultiplier(dmgMultiplier);
        newLightning.GetComponent<GenerateLightningLine>().SetTargetPos(target.transform.position);
        //Also deal damage to that enemy
        newLightning.GetComponent<LightningDamager>().DamageTarget(target);
    }

    void GetLightningStats(){
        Lightning lightningStats = relicManager.GetComponent<Lightning>();
        dmgMultiplier = lightningStats.dmgMultiplier;
        
        //Get num of lightning strikes that can be generated at a time
        numOfLightningStrikes = lightningStats.numOfLightningStrikes;
    }

    public override void Upgrade()
    {
        base.Upgrade();
    }
}
