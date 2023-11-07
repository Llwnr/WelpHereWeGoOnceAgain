using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class HideFullyUnlockedSkillTree : MonoBehaviour
{
    private void OnEnable() {
        //Don't show this tree if all the skills are unlocked
        if(TreeCompletelyUnlocked()) gameObject.SetActive(false);
    }

    //To know if you have unlocked all the skills of a tree. If so, don't show the tree anymore
    public bool TreeCompletelyUnlocked(){
        foreach(RelicSkillManager relicSkillManager in GetComponentsInChildren<RelicSkillManager>(true)){
            if(!relicSkillManager.isUnlocked && !relicSkillManager.isBlocked) return false;
        }
        return true;
    }
}
