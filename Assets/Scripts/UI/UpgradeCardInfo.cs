using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class UpgradeCardInfo : MonoBehaviour
{
    [SerializeField]private RelicUpgrader relicUpgrader;
    [SerializeField]private TextMeshProUGUI nameBox, descBox;
    // Start is called before the first frame update
    void Start()
    {
        nameBox.text = relicUpgrader.name;
        descBox.text = relicUpgrader.description[0];
    }

    public void PurchaseUpgrade(){
        relicUpgrader.Upgrade();
    }

    public RelicUpgrader GetRelicUpgrader(){
        return relicUpgrader;
    }
}
