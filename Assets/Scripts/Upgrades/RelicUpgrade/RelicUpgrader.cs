using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class RelicUpgrader : MonoBehaviour
{
    public new string name;
    public Sprite icon;
    public List<string> description;
    //The gameobject that will hold all the relics
    protected GameObject relicManager;
    //Priority of the relic based on first unlock, second unlock, third unlock etc
    // [SerializeField]protected int priority;
    private void Awake() {
        relicManager = GameObject.FindWithTag("RelicManager");
    }
    //Where all the upgrades will take place
    public abstract void Upgrade();

    private void OnEnable() {
        Awake();
        Upgrade();
    }
}
