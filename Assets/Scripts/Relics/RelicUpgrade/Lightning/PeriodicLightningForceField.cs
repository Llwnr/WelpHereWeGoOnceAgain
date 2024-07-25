using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PeriodicLightningForceField : TimerBasedRelicSkill
{
    [SerializeField]private GameObject lightning;
    private float dmgMultiplier;
    private float duration;
    private Vector2 scale;
    protected override void ActivateSkill()
    {
        //Get info about lightning such as duration, dmg power etc
        GetLightningStats();

        GameObject lightningPivot = Instantiate(lightning, GameObject.FindWithTag("Player").transform.position + new Vector3(0,0,1), Quaternion.identity);
        GameObject newLightning = lightningPivot.transform.GetChild(0).gameObject;
        newLightning.GetComponent<LightningDamager>().SetDmgMultiplier(dmgMultiplier);
        newLightning.GetComponent<LightningAnimManager>().SetDuration(duration);
        lightningPivot.transform.localScale = scale;
    }

    void GetLightningStats(){
        Lightning lightningStats = relicManager.GetComponent<Lightning>();
        dmgMultiplier = lightningStats.dmgMultiplier;
        duration = lightningStats.lightningDuration;
        scale = lightningStats.lightningFieldRange;
    }

    public override void Upgrade()
    {
        base.Upgrade();
    }
}
