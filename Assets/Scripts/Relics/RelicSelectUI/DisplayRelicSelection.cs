using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DisplayRelicSelection : MonoBehaviour, IOnLevelUp
{
    private void Start() {
        PlayerLevelManager.AddLevelupListener(this);
        gameObject.SetActive(false);
    }

    private void OnDestroy() {
        PlayerLevelManager.RemoveLevelupListener(this);
    }

    public void OnLevelUp()
    {
        gameObject.SetActive(true);
        Time.timeScale = 0;
    }

    public void OnDisable(){
        gameObject.SetActive(false);
        Time.timeScale = 1;
    }
}
