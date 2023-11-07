using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class RelicInfo : MonoBehaviour
{
    [SerializeField]private TextMeshProUGUI relicName, relicDesc;
    [SerializeField]private Image relicIcon;
    [SerializeField]private Relic relic;
    
    public void SetRelicInfo(string name, string desc, Sprite icon, Relic relic){
        relicName.text = name;
        relicDesc.text = desc;
        relicIcon.sprite = icon;
        this.relic = relic;
    }

    public Relic GetRelic(){
        return relic;
    }
}
