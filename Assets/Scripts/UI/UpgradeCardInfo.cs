using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class UpgradeCardInfo : MonoBehaviour
{
    [SerializeField]private RelicUpgrader relicUpgrader;
    [SerializeField]private TextMeshProUGUI nameBox, descBox;
    [SerializeField]private Image iconImg;

    // Start is called before the first frame update
    void Start()
    {
        nameBox.text = relicUpgrader.name;
        descBox.text = relicUpgrader.description[0];
        iconImg.sprite = relicUpgrader.icon;
    }

    public void PurchaseUpgrade(){
        relicUpgrader.Upgrade();
    }

    public RelicUpgrader GetRelicUpgrader(){
        return relicUpgrader;
    }
}
