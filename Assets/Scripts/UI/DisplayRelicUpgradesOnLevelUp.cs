using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DisplayRelicUpgradesOnLevelUp : MonoBehaviour, IOnLevelUp
{
    [SerializeField]private GameObject relicUpgraderUI;

    private void Start() {
        PlayerLevelManager.AddLevelupListener(this);
    }

    private void OnDisable() {
        PlayerLevelManager.RemoveLevelupListener(this);
    }

    public void OnLevelUp()
    {
        relicUpgraderUI.SetActive(true);
        Time.timeScale = 0;
    }

    public void DisableUI(){
        relicUpgraderUI.SetActive(false);
        Time.timeScale = 1;
    }
}
