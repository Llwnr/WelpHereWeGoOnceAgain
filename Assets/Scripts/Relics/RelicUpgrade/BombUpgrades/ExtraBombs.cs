using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExtraBombs : RelicSkill
{
    [SerializeField]private int numofExtraBombs;
    [SerializeField]private Bomber.BombType bombType;
    public override void Upgrade(){
        relicManager.GetComponent<Bomber>().IncreaseNumberOfBombs(bombType, numofExtraBombs);
    }
}
