using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PeriodicLightningForceField : TimerBasedRelicSkill
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
        newLightning.GetComponent<LightningAnimManager>().SetDuration(duration);
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
