using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class SubRelic : MonoBehaviour, IOnAttack
{
    [SerializeField]protected string relicName, relicDescription;
    protected WeaponManager weaponManager;
    private void Start() {
        weaponManager = WeaponManager.instance;
        weaponManager.AddOnAttackListener(this);
        OnStart();
    }

    private void OnDisable() {
        weaponManager.RemoveOnAttackListener(this);
    }

    public virtual void OnAttack(){
        
    }
    //The stuff to do at the start of the scene
    protected virtual void OnStart(){

    }
    //The main skill function to activate
    public abstract void ActivateSkill();
}
