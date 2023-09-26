using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class PickRandomTree : MonoBehaviour
{
    [SerializeField]private int numOfTreesToPick;
    private List<GameObject> allChildTrees = new List<GameObject>();

    private List<GameObject> pickedTrees = new List<GameObject>();
    
    private void OnEnable() {
        allChildTrees.Clear();
        foreach(Transform child in transform){
            //Don't add already completed trees
            if(child.GetComponent<HideFullyUnlockedSkillTree>().TreeCompletelyUnlocked()) continue;
            allChildTrees.Add(child.gameObject);
        }

        PickTreesToEnable();
        DisableUnpickedTrees();
    }

    void PickTreesToEnable(){
        pickedTrees.Clear();
        if(numOfTreesToPick >= allChildTrees.Count){
            //Show all trees in that case
            return;
        }
        //Pick random trees
        for(int i=0; i<numOfTreesToPick; i++){
            int randomIndex = Random.Range(0, allChildTrees.Count);
            //If picked tree already is picked then redo loop
            if(pickedTrees.Contains(allChildTrees[randomIndex])){
                i--;
                continue;
            }else{
                pickedTrees.Add(allChildTrees[randomIndex]);
            }
        }
    }

    void DisableUnpickedTrees(){
        //Don't disable any trees. Display all the remaining trees if num of unlockable trees less than random numbers of trees to display 
        if(pickedTrees.Count == 0){
            foreach(GameObject tree in allChildTrees){
                tree.SetActive(true);
            }
            return;
        }

        //Disable all trees
        foreach(GameObject tree in allChildTrees){
            tree.SetActive(false);
        }

        //Then enabled picked trees
        foreach(GameObject tree in pickedTrees){
            tree.SetActive(true);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
