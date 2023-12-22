using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DisplayReload : MonoBehaviour, IOnReload
{
    private float reloadTime, maxReloadTime = 0;
    private Image reloadBar;

    private Image myImg;

    private void Start() {
        myImg = GetComponent<Image>();
        SetInvisible(true);

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
        this.reloadTime = 0;
    }

    private void Update() {
        if(Time.deltaTime == 0) return;
        reloadTime += Time.deltaTime;
        reloadBar.fillAmount = reloadTime/maxReloadTime;
    }

    public void OnReloadStart()
    {
        SetInvisible(false);
        reloadBar.fillAmount = 0;
        Reloaded(WeaponManager.instance.GetReloadTime());
    }

    public void OnReloadComplete(){
        SetInvisible(true);
    }

    //Make UIs visible or invisible for UI only
    void SetInvisible(bool value){
        myImg.enabled = !value;
        foreach(Image img in GetComponentsInChildren<Image>()){
            img.enabled = !value;
        }
    }
}
