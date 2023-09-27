using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelectUpgrade : MonoBehaviour
{
    //To show that the selected relic is being highlighted
    [SerializeField]private GameObject highlightBorder;
    private GameObject createdHighlightBorder;

    private RelicSkillManager selectedRelic;

    private void Start() {
        createdHighlightBorder = Instantiate(highlightBorder, Vector2.zero, Quaternion.identity);
        createdHighlightBorder.SetActive(false);
    }

    public void SetSelectedRelic(){
        //Get the mouse clicked relic's data
        GameObject selectedBtn = UnityEngine.EventSystems.EventSystem.current.currentSelectedGameObject;
        selectedRelic = selectedBtn.GetComponent<RelicSkillManager>();
        //Set description of selected relic
        
        //Also show the relic upgrade as selected through a highlighting border
        if(createdHighlightBorder == null){
            createdHighlightBorder = Instantiate(highlightBorder, Vector2.zero, Quaternion.identity);
        }
        createdHighlightBorder.SetActive(true);
        createdHighlightBorder.transform.SetParent(selectedBtn.transform, false);
    }

    //Use the currently selected relic and buy/run it
    public void ExecuteUpgrade(){
        if(selectedRelic == null){
            Debug.LogError("No relic skill selected to upgrade");
            return;
        }

        if(selectedRelic.UnlockSkill()){
            selectedRelic.SetAsUsed();
            //Hide the UI panel: 
            gameObject.SetActive(false);
        }else{
            Debug.LogError("Skill is not unlockable yet");
        }
    }
}
