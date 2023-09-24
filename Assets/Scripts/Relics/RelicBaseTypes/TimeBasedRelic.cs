using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class TimeBasedRelic : Relic
{
    [SerializeField]private float activationDuration;
    private float durationCounter;
    // Start is called before the first frame update
    void Start()
    {
        ResetDuration();
    }

    // Update is called once per frame
    void Update()
    {
        //Activate the relic skill on a timely basis
        durationCounter -= Time.deltaTime;
        if(durationCounter <= 0){
            ActivateSkill();
            ResetDuration();
        }
    }

    void ResetDuration(){
        durationCounter = activationDuration;
    }
}
