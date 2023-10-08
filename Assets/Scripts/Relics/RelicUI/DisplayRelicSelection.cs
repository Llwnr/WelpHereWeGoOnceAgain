using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DisplayRelicSelection : MonoBehaviour, IOnLevelUp
{
    private List<GameObject> myRelicCards = new List<GameObject>();
    private void Start() {
        PlayerLevelManager.AddLevelupListener(this);
        gameObject.SetActive(false);

        myRelicCards = GetComponent<AddRelicSelectionOptions>().GetMyRelicCards();
    }

    private void OnDestroy() {
        PlayerLevelManager.RemoveLevelupListener(this);
    }

    public void OnLevelUp()
    {
        gameObject.SetActive(true);
        Time.timeScale = 0;

        //Slight delay so player knows its upgrade time
        StartCoroutine(DisplayTwoRandomRelics());
    }

    public void OnDisable(){
        gameObject.SetActive(false);
        Time.timeScale = 1;
    }

    IEnumerator DisplayTwoRandomRelics(){
        //Pick two random cards
        List<int> pickedCardIndex = new List<int>();

        //Remove completely upgraded relics
        for(int i=0; i<myRelicCards.Count; i++){
            if(myRelicCards[i].GetComponent<RelicInfo>().GetRelic().allUpgradesPurchased){
                //Permanently disable the completely unlocked relic so that it can't be selected for upgrade anymore
                myRelicCards[i].SetActive(false);
                myRelicCards.Remove(myRelicCards[i]);
                i--;
            }
        }

        //Display upto 2 relics that can be selected for upgrading
        for(int i=0; i<Mathf.Min(2, myRelicCards.Count); i++){
            int newRandomIndex = Random.Range(0, myRelicCards.Count);
            if(pickedCardIndex.Contains(newRandomIndex)){
                i--;
                continue;
            }else{
                pickedCardIndex.Add(newRandomIndex);
            }
        }

        DisableAllCards();

        //Display those two cards only
        for(int i=0; i<pickedCardIndex.Count; i++){
            myRelicCards[pickedCardIndex[i]].gameObject.SetActive(true);
        }

        //Make button unclickable for a couple frames
        SetButtonsClickable(false);
        yield return new WaitForSecondsRealtime(0.5f);
        SetButtonsClickable(true);
    }

    void SetButtonsClickable(bool value){
        foreach(Button button in GetComponentsInChildren<Button>()){
            button.interactable = value;
            button.enabled = value;
        }
    }

    void DisableAllCards(){
        foreach(GameObject relicCard in myRelicCards){
            relicCard.gameObject.SetActive(false);
        }
    }
}
