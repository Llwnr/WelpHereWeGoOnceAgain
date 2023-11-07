using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ManageFullyUnlockedRelics : MonoBehaviour
{
    private RelicType.RelicTypes myRelicType;
    private Relic myRelic;

    private void OnDisable() {
        myRelicType = GetComponent<RelicType>().GetRelicType();
        //Find the relic type that matches the tree's relic type
        foreach(Relic relic in GameObject.FindWithTag("RelicManager").GetComponents<Relic>()){
            if(relic.myRelicType == myRelicType){
                myRelic = relic;
                break;
            }
        }

        //Check if all the upgrades of the tree is completed
        bool allSkillsUnlocked = true;
        foreach(HideFullyUnlockedSkillTree skillTreeInfo in GetComponentsInChildren<HideFullyUnlockedSkillTree>()){
            if(!skillTreeInfo.TreeCompletelyUnlocked()){
                allSkillsUnlocked = false;
            }
        }

        //Set relic as completely unlocked if all skills of that relic type are unlocked
        if(allSkillsUnlocked){
            myRelic.SetAllUpgradesAsPurchased();
        }
    }
}
