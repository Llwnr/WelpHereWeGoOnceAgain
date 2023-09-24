using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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

        
        DisplayTwoRandomRelics();
    }

    public void OnDisable(){
        gameObject.SetActive(false);
        Time.timeScale = 1;
    }

    void DisplayTwoRandomRelics(){
        //Pick two random cards
        List<int> pickedCardIndex = new List<int>();
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
    }

    void DisableAllCards(){
        foreach(GameObject relicCard in myRelicCards){
            relicCard.gameObject.SetActive(false);
        }
    }
}
