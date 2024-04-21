using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBasicStats : MonoBehaviour, IOnLevelUp
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

    private void Update() {
        return;
        if(Input.GetKeyDown(KeyCode.C)){
            PlayerLevelManager.LevelUp();
            Debug.Log("Forced level up from here");
        }
    }

    private void Start() {
        PlayerLevelManager.AddLevelupListener(this);
    }

    private void OnDisable() {
        PlayerLevelManager.RemoveLevelupListener(this);
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

    //FOR UPGRADES
    public void BuffMovementSpeedBy(float amt){
        movementSpeedMultiplier += amt;
    }

    //When you level up you will upgrade your stats
    public void OnLevelUp(){
        UpgradeStat();
    }

    public void UpgradeStat(){
        //Each level up will increase certain stats by certain amt
        //For excample on crit chance = +0.5% crit chance
        //On max hp = +2 max hp;
        maxHp += 2;
        atkSpeedMultiplier += 0.01f;
        atkPowerMultiplier += 0.01f;
        critChance += 0.5f;
        critDamage += 1;
        reloadSpeedMultiplier += 0.01f;
        movementSpeedMultiplier += 0.005f;
    }
}
