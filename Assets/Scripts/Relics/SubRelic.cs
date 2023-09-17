using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class SubRelic : MonoBehaviour, IOnAttack
{
    [Header ("Info")]
    public string relicName;
    [TextArea]
    public string relicDescription;
    public Sprite icon;
    public RelicType.RelicTypes myRelicType;
    protected GameObject player;
    protected WeaponManager weaponManager;
    private void Start() {
        player = GameObject.FindWithTag("Player");
        weaponManager = WeaponManager.instance;
        weaponManager.AddOnAttackListener(this);
        OnStart();
    }

    private void OnDisable() {
        weaponManager.RemoveOnAttackListener(this);
    }
    //The stuff to do at the start of the scene
    protected virtual void OnStart(){

    }
    //The stuff to do when player shoots a bullet
    public virtual void OnAttack(){
        
    }

    //All the relic upgrades will be updated using this function
    public virtual void UpdateRelicUpgrades(){

    }
    
    //The main skill function to activate
    public abstract void ActivateSkill();
}
