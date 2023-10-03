using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class TimerBasedRelicSkill : RelicSkill, IRunUpdateFuncEvenWhenDisabled
{
    [SerializeField]private float interval;//Time taken for skill to activate
    private float intervalCount;

    protected abstract void ActivateSkill();

    public override void Upgrade(){//Works as Start() function so
        TimeManager.instance.AddTimeListener(this);
        ResetInterval();
    }

    private void OnDestroy() {
        TimeManager.instance.RemoveTimeListener(this);
    }

    void ResetInterval(){
        intervalCount = interval;
    }

    public void RunUpdate(){
        //Don't start countdown if skill is not unlocked
        if(!GetComponent<RelicSkillManager>().isUnlocked) return;

        intervalCount -= Time.deltaTime;

        if(intervalCount <= 0){
            ResetInterval();
            ActivateSkill();
        }
    }
}
