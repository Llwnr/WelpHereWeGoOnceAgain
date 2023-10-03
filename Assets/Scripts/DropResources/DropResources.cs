using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DropResources : MonoBehaviour, IOnDeath
{
    [SerializeField]private float expDropAmt;
    [Header ("Droppable items")]
    [SerializeField]private List<GameObject> items;
    private float dropChance = 5;
    //This will be dropped when enemies die as exp points for player
    [SerializeField]private GameObject expDrop;
    
    private void Start() {
        GetComponent<EnemyHpManager>().AddDeathListener(this);
    }

    public void OnDeath(){
        //Drop the exp
        ExpData expData = Instantiate(expDrop, transform.position, Quaternion.identity).GetComponent<ExpData>();
        expData.SetExpAmt(expDropAmt);

        //Drop items on chance
        if(Random.Range(0f, 100f) <= dropChance){
            int randomItemIndex = Random.Range(0, items.Count);
            Instantiate(items[randomItemIndex], transform.position, Quaternion.identity);
        }
        
    }
}
