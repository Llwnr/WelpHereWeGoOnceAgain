using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DropResources : MonoBehaviour, IOnDeath
{
    [SerializeField]private float expDropAmt;
    //This will be dropped when enemies die as exp points for player
    [SerializeField]private GameObject expDrop;
    
    private void Start() {
        GetComponent<EnemyHpManager>().AddDeathListener(this);
    }

    public void OnDeath(){
        //Drop the exp
        ExpData expData = Instantiate(expDrop, transform.position, Quaternion.identity).GetComponent<ExpData>();
        expData.SetExpAmt(expDropAmt);

    }
}
