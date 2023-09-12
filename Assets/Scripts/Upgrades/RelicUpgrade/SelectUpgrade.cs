using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SelectUpgrade : MonoBehaviour
{
    //To show that the selected relic is being highlighted
    [SerializeField]private GameObject highlightBorder;
    private bool upgradeSelected = false;

    [SerializeField]private RelicUpgrader selectedRelic;

    //Get the mouse clicked relic's data
    public void SetSelectedRelic(){
        GameObject selectedBtn = UnityEngine.EventSystems.EventSystem.current.currentSelectedGameObject;
        selectedRelic = selectedBtn.GetComponent<UpgradeCardInfo>().GetRelicUpgrader();
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
