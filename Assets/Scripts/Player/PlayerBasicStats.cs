using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBasicStats : MonoBehaviour
{
    //Singleton class
    public static PlayerBasicStats instance{get; private set;}

    private void Awake() {
        if(instance!=null){
            Debug.LogError("More than one player basic stats script");
            return;
        }
        instance = this;
    }

    //All the stats of players. Upgrades will improve these stats
    [SerializeField]private int maxHp;
    [SerializeField]private float atkSpeedMultiplier, atkPowerMultiplier, reloadSpeedMultiplier = 1;
    [SerializeField]private float movementSpeedMultiplier = 1;

    public int GetMaxHp(){
        return maxHp;
    }

    public float GetAtkSpeed(){
        return atkSpeedMultiplier;
    }

    public float GetAtkPower(){
        return atkPowerMultiplier;
    }

    public float GetReloadSpeed(){
        return reloadSpeedMultiplier;
    }

    public float GetMovementSpeed(){
        return movementSpeedMultiplier;
    }
}
