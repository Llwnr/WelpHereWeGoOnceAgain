using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DisplayRelicOptions : MonoBehaviour
{
    private List<SubRelic> equippableRelic = new List<SubRelic>();
    [SerializeField]private GameObject relicHolder, relicUIHolder;
    [SerializeField]private GameObject relicCard;

    private void Start() {
        //All the disabled relics will be stored and displayed randomly for relic selection
        foreach(SubRelic relic in relicHolder.GetComponents<SubRelic>()){
            equippableRelic.Add(relic);
        }

        GenerateRelicCards();
    }

    void GenerateRelicCards(){
        foreach(SubRelic relic in equippableRelic){
            //Generate empty relic cards
            GameObject newCard = Instantiate(relicCard, Vector2.zero, Quaternion.identity);
            newCard.transform.SetParent(relicUIHolder.transform, false);
            //Set info on those cards based on relic data
            RelicInfo relicInfo = newCard.GetComponent<RelicInfo>();
            relicInfo.SetRelicInfo(relic.relicName, relic.relicDescription, relic.icon);
        }
    }


}
