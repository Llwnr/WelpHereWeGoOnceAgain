using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(RelicSkillManager))]
public abstract class RelicSkill : MonoBehaviour
{  
    //The gameobject that will hold all the relics
    protected GameObject relicManager;
    protected RelicSkillManager relicSkillManager;

    private void Awake() {
        relicManager = GameObject.FindWithTag("RelicManager");
        relicSkillManager = GetComponent<RelicSkillManager>();
    }
    //Where all the upgrades will take place
    public abstract void Upgrade();
}
