using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TwoNormalBombs : U_YellowBomb
{
    public override void Upgrade(){
        relicManager.GetComponent<ThrowBombs>().IncreaseNumberOfBombsBy(2);
        Debug.Log("Upgraded");
    }
}
