using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UICreateRelicUpgrades : MonoBehaviour
{
    [SerializeField]private GameObject upgradeUI, upgradeCard;
    private List<GameObject> newCards = new List<GameObject>();

    [SerializeField]private GameObject upgradeHolderForTargetRelicType = null;
    
    public void ActivateUpgradeSelection(RelicType.RelicTypes selectedRelicType) {
        Time.timeScale = 0;
        //Create the cards
        GameObject relicUpgradeHolder = GameObject.FindWithTag("RelicManager");

        //Find the upgrades that is for the given relic type
        upgradeHolderForTargetRelicType = null;
        foreach(RelicType relicType in relicUpgradeHolder.GetComponentsInChildren<RelicType>()){
            if(relicType.GetRelicType() == selectedRelicType){
                upgradeHolderForTargetRelicType = relicType.gameObject;
                break;
            }
        }

        //Display the upgrades for that relic
        foreach(RelicUpgrader relicUpgrader in upgradeHolderForTargetRelicType.GetComponents<RelicUpgrader>()){
            //Only show upgrades that haven't been activated yet
            if(relicUpgrader.HasBeenUsed()) continue;

            Debug.Log("Creating card for " + relicUpgrader.name);
            GameObject newCard = Instantiate(upgradeCard, Vector2.zero, Quaternion.identity);
            newCard.transform.SetParent(upgradeUI.transform, false);
            //Give upgrades info
            newCard.GetComponent<UpgradeCardInfo>().SetCardInfo(relicUpgrader);
            newCards.Add(newCard);
            //Give on click functions such as "make the button be selected on click"
            newCard.GetComponent<Button>().onClick.AddListener(GetComponent<SelectUpgrade>().SetSelectedRelic);
        }
    }

    private void OnDisable() {
        Time.timeScale = 1;
        //Empty cards after picking one
        foreach(GameObject card in newCards){
            Destroy(card);
        }
        newCards.Clear();
    }


}
