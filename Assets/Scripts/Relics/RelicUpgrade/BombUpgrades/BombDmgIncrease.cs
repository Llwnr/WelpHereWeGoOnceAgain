using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BombDmgIncrease : RelicSkill
{
    [SerializeField]private float increaseMultiplier;
    [SerializeField]private Bomber.BombType bombType;
    
    public override void Upgrade(){
        relicManager.GetComponent<Bomber>().IncreaseDmgMultiplier(bombType, increaseMultiplier);
    }
}
