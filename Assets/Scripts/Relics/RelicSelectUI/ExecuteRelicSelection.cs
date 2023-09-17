using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ExecuteRelicSelection : MonoBehaviour
{
    [SerializeField]private GameObject relicUpgradeUI;
    public void EnableRelic(){
        //Enable the selected relic
        GameObject clickedBtn = UnityEngine.EventSystems.EventSystem.current.currentSelectedGameObject;
        RelicInfo relicInfo = clickedBtn.GetComponent<RelicInfo>();
        relicInfo.GetRelic().enabled = true;

        //Hide current "relic" selection UI to show "relc upgrade" selection UI
        gameObject.SetActive(false);

        //Then show various upgradables of that selected relic for selection
        DisplayRelicUpgrades(relicInfo.GetRelic().myRelicType);
    }

    void DisplayRelicUpgrades(RelicType.RelicTypes relicType){
        relicUpgradeUI.SetActive(true);
        relicUpgradeUI.GetComponent<UICreateRelicUpgrades>().ActivateUpgradeSelection(relicType);
    }
}
