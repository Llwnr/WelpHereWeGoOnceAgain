using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//These skills will check if they can proc based on chance with every attack
public abstract class ChanceBasedSkill : SubRelic
{
    [SerializeField]protected float procChance;

    protected override void OnStart(){
        
    }

    public override void OnAttack(){
        float randomValue = Random.Range(0, 100);
        if(randomValue <= procChance){
            ActivateSkill();
        }
    }
}
