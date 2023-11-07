using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AddRelicSelectionOptions : MonoBehaviour
{
    private List<Relic> equippableRelic = new List<Relic>();
    private List<GameObject> relicCards = new List<GameObject>();
    [SerializeField]private GameObject relicHolder, relicUIHolder;
    [SerializeField]private GameObject relicCard;

    private void Awake() {
        //All the disabled relics will be stored and displayed randomly for relic selection
        foreach(Relic relic in relicHolder.GetComponents<Relic>()){
            equippableRelic.Add(relic);
        }

        GenerateRelicCards();
    }

    void GenerateRelicCards(){
        foreach(Relic relic in equippableRelic){
            //Generate empty relic cards
            GameObject newCard = Instantiate(relicCard, Vector2.zero, Quaternion.identity);
            newCard.transform.SetParent(relicUIHolder.transform, false);
            //Set info on those cards based on relic data
            newCard.name = relic.relicName;
            RelicInfo relicInfo = newCard.GetComponent<RelicInfo>();
            relicInfo.SetRelicInfo(relic.relicName, relic.relicDescription, relic.icon, relic);

            //Also give it scripts to execute when button clicked
            newCard.GetComponent<Button>().onClick.AddListener(GetComponent<ExecuteRelicSelection>().EnableRelic);

            newCard.SetActive(false);
            relicCards.Add(newCard);

        }
    }

    public List<GameObject> GetMyRelicCards(){
        return relicCards;
    }


}
