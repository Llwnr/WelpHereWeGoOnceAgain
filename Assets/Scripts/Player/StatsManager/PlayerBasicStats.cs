using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBasicStats : MonoBehaviour
{
    public enum PlayerStatType{
        maxHp, currHp, atkSpeed, atkPower, reloadSpeed, critChance, critDamage, movementSpeed
    }
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
    [SerializeField]private float critChance, critDamage;
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
    public float GetCritChance(){
        return critChance;
    }
    public float GetCritDamage(){
        return critDamage;
    }

    public void UpgradeStat(PlayerStatType statType){
        //Each 1 point of upgrade will increase certain stats by certain amt
        //for excample 1 point on crit chance = +0.5% crit chance
        //1 point on max hp = +5 max hp;
        switch(statType){
            case PlayerStatType.maxHp:
                maxHp += 5;
                break;
            case PlayerStatType.currHp:

                break;
            case PlayerStatType.atkSpeed:
                atkSpeedMultiplier += 0.05f;
                break;
            case PlayerStatType.atkPower:
                atkPowerMultiplier += 0.05f;
                break;
            case PlayerStatType.critChance:
                critChance += 0.5f;
                break;
            case PlayerStatType.critDamage:
                critDamage += 1;
                break;
            case PlayerStatType.reloadSpeed:
                reloadSpeedMultiplier += 0.05f;
                break;
            case PlayerStatType.movementSpeed:
                movementSpeedMultiplier += 0.05f;
                break;
            default:
                Debug.LogError("Invalid stats to upgrade.");
                break;
        }
    }
}
