using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StatsUpgrader : MonoBehaviour
{
    [SerializeField]private PlayerBasicStats.PlayerStatType statType;
    
    public void UpgradeStat(){
        GameObject.FindWithTag("Player").GetComponent<PlayerBasicStats>().UpgradeStat(statType);
    }
}
