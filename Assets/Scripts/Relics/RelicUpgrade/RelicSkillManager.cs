using System.Collections;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Button))]
public class RelicSkillManager : MonoBehaviour
{
    public new string name;
    public Sprite icon;
    [TextArea(5,10)]
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

        SetupDescColors();
    }

    //This will give color to description keywords such as "increase to green color", "decrease to red" etc
    void SetupDescColors(){
        Regex regex = new Regex("[ \n]");
        string[] words = regex.Split(description);
        string newDesc = "";
        int wordSkipCount = 0;

        foreach(string word in words){
            string newWord = word;
            if(wordSkipCount > 0){
                wordSkipCount--;
                if(wordSkipCount == 0){
                    newDesc += "</color>";
                }
            }
            if(word == "Increases" || word == "extra" || word == "more" || word == "Increase"){
                newWord = "<color=green>" + word + "</color>";
            }else if(word == "Reduces" || word == "less"){
                newWord = "<color=red>" + word + "</color>";
            }
            //For descriptions with relic activation condition such as "Every x shots"
            else if(word == "Every"){
                wordSkipCount = 3;
                newDesc += "<color=yellow>" + word + " ";
                continue;
            }
            else if(word == "After"){
                wordSkipCount = 2;
                newDesc += "<color=purple>" + word + " ";
                continue;
            }
            newDesc += newWord + " ";
        }
        description = newDesc;
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
        //To change disabled buttons color
        var buttonColors = GetComponent<Button>().colors;
        buttonColors.disabledColor = Color.white;
        GetComponent<Button>().colors = buttonColors;
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

            GetComponent<Image>().color = Color.yellow;

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
