using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExtraYBombs : RelicSkill
{
    [SerializeField]private int numofExtraBombs;
    public override void Upgrade(){
        relicManager.GetComponent<ThrowBombs>().IncreaseNumberOfBombsBy(numofExtraBombs);
        Debug.Log("Upgraded qwe asd");
    }
}
