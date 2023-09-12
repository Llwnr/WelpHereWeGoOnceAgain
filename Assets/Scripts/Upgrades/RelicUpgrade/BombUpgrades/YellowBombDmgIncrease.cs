using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class YellowBombDmgIncrease : U_YellowBomb
{
    [SerializeField]private float increaseMultiplier;
    
    public override void Upgrade(){
        float currMultiplier = relicManager.GetComponent<ThrowBombs>().GetDamageMultiplier();
        relicManager.GetComponent<ThrowBombs>().SetDamageMultiplier(currMultiplier+increaseMultiplier);

        Debug.Log("Bomb dmg multiplier increased");
    }
}
