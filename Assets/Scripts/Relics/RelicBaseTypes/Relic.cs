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

    private void Start(){
        player = GameObject.FindWithTag("Player");
        weaponManager = WeaponManager.instance;
    }

}
