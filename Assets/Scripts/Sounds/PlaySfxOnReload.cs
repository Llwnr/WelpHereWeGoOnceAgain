using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using FMODUnity;

public class PlaySfxOnReload : MonoBehaviour, IOnReload
{
    public EventReference reloadStartSfx, reloadCompleteSfx;

    private void Start() {
        WeaponManager.instance.AddOnReloadListener(this);
    }

    private void OnDisable() {
        if(WeaponManager.instance) WeaponManager.instance.RemoveOnReloadListener(this);
    }

    public void OnReloadStart()
    {
        RuntimeManager.PlayOneShot(reloadStartSfx);
    }

    public void OnReloadComplete(){
        RuntimeManager.PlayOneShot(reloadCompleteSfx);
    }
}
