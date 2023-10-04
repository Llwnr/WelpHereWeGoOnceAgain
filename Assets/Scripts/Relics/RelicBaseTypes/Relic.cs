using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Relic : MonoBehaviour
{
    [Header ("Info")]
    public string relicName;
    [TextArea]
    public string relicDescription;
    public Sprite icon;
    public RelicType.RelicTypes myRelicType;
    protected GameObject player;
    protected WeaponManager weaponManager;

    //To know if the relic's all upgrades have been purchased or not so that they're not shown on upgrades panel anymore
    public bool allUpgradesPurchased{get; private set;} = false;

    private void Start(){
        player = GameObject.FindWithTag("Player");
        weaponManager = WeaponManager.instance;
    }

    public void SetAllUpgradesAsPurchased(){
        allUpgradesPurchased = true;
    }

}
