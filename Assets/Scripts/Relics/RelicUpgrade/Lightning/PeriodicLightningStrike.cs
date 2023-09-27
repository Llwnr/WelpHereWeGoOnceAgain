using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PeriodicLightningStrike : TimerBasedRelicSkill
{
    [SerializeField]private GameObject lightning;
    public override void ActivateSkill()
    {
        Debug.Log("Lightning created");
        Instantiate(lightning, GameObject.FindWithTag("Player").transform.position + new Vector3(0,0,1), Quaternion.identity);
    }

    public override void Upgrade()
    {
        base.Upgrade();
    }
}
