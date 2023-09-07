using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DisplayReload : MonoBehaviour
{
    private float reloadTime, maxReloadTime = 0;
    private Image reloadBar;

    private void Start() {
        reloadBar = GetComponent<Image>();
    }

    public void Reloaded(float reloadTime){
        maxReloadTime = reloadTime;
        this.reloadTime = reloadTime;
    }

    private void Update() {
        reloadTime -= Time.deltaTime;
        reloadBar.fillAmount = reloadTime/maxReloadTime;
    }
}
