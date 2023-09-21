using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class UpgradeCardInfo : MonoBehaviour
{
    [SerializeField]private RelicSkill relicUpgrader;
    [SerializeField]private TextMeshProUGUI nameBox;
    private string desc;
    [SerializeField]private Image iconImg;

    public void SetCardInfo(RelicSkill relicUpgrade){
        relicUpgrader = relicUpgrade;
        nameBox.text = relicUpgrade.name;
        desc = relicUpgrade.description[0];
        iconImg.sprite = relicUpgrade.icon;
    }

    public string GetUpgradeDesc(){
        return desc;
    }

    public void PurchaseUpgrade(){
        relicUpgrader.Upgrade();
    }

    public RelicSkill GetRelicUpgrader(){
        return relicUpgrader;
    }
}
