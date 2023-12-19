using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DisplayReload : MonoBehaviour, IOnReload
{
    [SerializeField]private float reloadTime, maxReloadTime = 0;
    private Image reloadBar;

    private void Start() {
        reloadBar = GetComponent<Image>();

        //Subscribe to listen to reload
        WeaponManager.instance.AddOnReloadListener(this);
    }

    private void OnDisable() {
        if(WeaponManager.instance) WeaponManager.instance.RemoveOnReloadListener(this);
    }

    //Set reload values
    void Reloaded(float reloadTime){
        maxReloadTime = reloadTime;
        this.reloadTime = reloadTime;
    }

    private void Update() {
        if(Time.deltaTime == 0) return;
        reloadTime -= Time.deltaTime;
        reloadBar.fillAmount = reloadTime/maxReloadTime;
    }

    public void OnReload()
    {
        Reloaded(WeaponManager.instance.GetReloadTime());
    }
}
