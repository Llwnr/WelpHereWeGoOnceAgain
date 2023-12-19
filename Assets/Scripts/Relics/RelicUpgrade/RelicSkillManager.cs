using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Button))]
public class RelicSkillManager : MonoBehaviour
{
    public new string name;
    public Sprite icon;
    [TextArea]
    public string description;

    public bool isUnlocked{get; private set;} = false;
    public bool isBlocked{get; private set;} = false;
    //SKILL TREE MANAGER
    public List<RelicSkillManager> myRequiredNodes = new List<RelicSkillManager>();//The upgrades that need to be already unlocked for this skill to be unlockable
    protected List<RelicSkillManager> myConnectedChildNodes = new List<RelicSkillManager>();

    private void Start() {
        foreach(RelicSkillManager parentUpgrader in myRequiredNodes){
            //Add this as a child to the target parent
            parentUpgrader.myConnectedChildNodes.Add(this);
        }
    }

    private void OnEnable(){
        //Check if required nodes are blocked. If all of them are blocked then block self too.
        bool requiredNodesUnlockable = false;
        foreach(RelicSkillManager parentUpgrader in myRequiredNodes){
            if(!parentUpgrader.isBlocked) requiredNodesUnlockable = true;
        }
        if(!requiredNodesUnlockable && myRequiredNodes.Count > 0) isBlocked = true;


        //Make the skill selectable only when it can be unlocked
        if(CanBeUnlocked() && !isUnlocked && !isBlocked){
            GetComponent<Button>().interactable = true;
        }else{
            GetComponent<Button>().interactable = false;
        }
    }

    protected void BlockChildrenExceptMe(RelicSkillManager upgrader){
        //Once a pathway of skill tree is picked, block other pathways of that parent
        foreach(RelicSkillManager parentUpgrader in myRequiredNodes){
            foreach(RelicSkillManager otherPathwayUpgrader in parentUpgrader.myConnectedChildNodes){
                if(upgrader != otherPathwayUpgrader){
                    otherPathwayUpgrader.isBlocked = true;
                    
                    otherPathwayUpgrader.GetComponent<Button>().interactable = false;
                }
            }
        }
    }

    public void SetAsUsed(){
        isUnlocked = true;
    }
    public bool HasBeenUnlocked(){
        return isUnlocked;
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
            //Activate all relic skills of this gameobject
            foreach(RelicSkill relicSkill in gameObject.GetComponents<RelicSkill>()){
                relicSkill.Upgrade();
            }

            GetComponent<Image>().color = Color.grey;

            return true;
        }
        else {
            Debug.Log("Skill already unlocked");
        }

        return false;
    }

    public bool CanBeUnlocked(){
        bool conditionSatisfied = false;
        //If there is no required parents then the skill is able to be unlocked
        if(myRequiredNodes.Count <= 0) conditionSatisfied = true;
        //If any one of the requiredParents is unlocked then this is unlockable too
        foreach(RelicSkillManager upgraders in myRequiredNodes){
            if(upgraders.isUnlocked) conditionSatisfied = true;
        }

        return conditionSatisfied;
    }

    public List<Transform> GetRequiredNodesTransform(){
        List<Transform> myTransforms = new List<Transform>();
        foreach(RelicSkillManager relicSkillManager in myRequiredNodes){
            myTransforms.Add(relicSkillManager.transform);
        }
        
        return myTransforms;
    }
}
