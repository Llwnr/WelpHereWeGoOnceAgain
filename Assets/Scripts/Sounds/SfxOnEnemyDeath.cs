using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using FMOD.Studio;
using FMODUnity;

public class SfxOnEnemyDeath : MonoBehaviour
{
    public EventReference sfx;
    private EnemyHpManager hpManager;
    private bool alreadyActivated = false;

    private void Start() {
        hpManager = GetComponent<EnemyHpManager>();
    }
    
    private void Update() {
        if(hpManager.alreadyDead && !alreadyActivated){
            RuntimeManager.PlayOneShot(sfx);
            alreadyActivated = true;
        }
    }
}
