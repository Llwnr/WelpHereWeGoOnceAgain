using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SelectUpgrade : MonoBehaviour
{
    //To show that the selected relic is being highlighted
    [SerializeField]private GameObject highlightBorder;
    private GameObject createdHighlightBorder;

    [SerializeField]private RelicUpgrader selectedRelic;

    private void Start() {
        createdHighlightBorder = Instantiate(highlightBorder, Vector2.zero, Quaternion.identity);
        createdHighlightBorder.SetActive(false);
    }

    public void SetSelectedRelic(){
        //Get the mouse clicked relic's data
        GameObject selectedBtn = UnityEngine.EventSystems.EventSystem.current.currentSelectedGameObject;
        selectedRelic = selectedBtn.GetComponent<UpgradeCardInfo>().GetRelicUpgrader();
        
        //Also show the relic upgrade as selected through a highlighting border
        createdHighlightBorder.SetActive(true);
        createdHighlightBorder.transform.SetParent(selectedBtn.transform, false);
    }

    //Use the currently selected relic and buy/run it
    public void ExecuteUpgrade(){
        if(selectedRelic == null){
            Debug.LogError("No relic upgrade selected");
            return;
        }

        selectedRelic.Upgrade();
    }
}
