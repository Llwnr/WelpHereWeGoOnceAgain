using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public abstract class RelicSkill : MonoBehaviour
{
    public new string name;
    public Sprite icon;
    [TextArea]
    public List<string> description;
    private bool isUnlocked = false;
    private bool isBlocked = false;

    public void SetAsUsed(){
        isUnlocked = true;
    }
    public bool HasBeenUnlocked(){
        return isUnlocked;
    }
    //The gameobject that will hold all the relics
    protected GameObject relicManager;

    private void Awake() {
        relicManager = GameObject.FindWithTag("RelicManager");
    }
    //Where all the upgrades will take place
    public abstract void Upgrade();

    private void OnEnable() {
        Awake();
    }

    //SKILL TREE MANAGER
    public List<RelicSkill> myRequiredNodes;//The upgrades that need to be already unlocked for this skill to be unlockable
    protected List<RelicSkill> myConnectedChildNodes = new List<RelicSkill>();

    private void Start() {
        foreach(RelicSkill parentUpgrader in myRequiredNodes){
            //Add this as a child to the target parent
            parentUpgrader.myConnectedChildNodes.Add(this);
        }
    }

    protected void BlockChildrenExceptMe(RelicSkill upgrader){
        //Once a pathway of skill tree is picked, block other pathways of that parent
        foreach(RelicSkill parentUpgrader in myRequiredNodes){
            foreach(RelicSkill otherPathwayUpgrader in parentUpgrader.myConnectedChildNodes){
                if(upgrader != otherPathwayUpgrader){
                    otherPathwayUpgrader.isBlocked = true;
                    otherPathwayUpgrader.GetComponent<Button>().interactable = false;
                }
            }
        }
    }

    //Unlock the skill
    public virtual bool UnlockSkill(){
        if(!CanBeUnlocked()){
            Debug.LogError("Previous skills not unlocked");
            return false;
        }

        if(isBlocked){
            Debug.LogError("This skill can't be unlocked anymore");
            return false;
        }
       
       //Unlock if it hasn't been 
        if(!isUnlocked){//This one means succesfully unlocked
            isUnlocked = true;
            BlockChildrenExceptMe(this);
            //Activate this skill
            Upgrade();

            GetComponent<Image>().color = Color.red;

            return true;
        }

        return false;
    }


    public bool CanBeUnlocked(){
        bool conditionSatisfied = false;
        //If there is no required parents then the skill is able to be unlocked
        if(myRequiredNodes.Count <= 0) conditionSatisfied = true;
        //If any one of the requiredParents is unlocked then this is unlockable too
        foreach(RelicSkill upgraders in myRequiredNodes){
            if(upgraders.isUnlocked) conditionSatisfied = true;
        }

        return conditionSatisfied;
    }
}
