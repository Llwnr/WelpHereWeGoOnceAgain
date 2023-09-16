using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class RelicInfo : MonoBehaviour
{
    [SerializeField]private TextMeshProUGUI relicName, relicDesc;
    [SerializeField]private Image relicIcon;
    
    public void SetRelicInfo(string name, string desc, Sprite icon){
        relicName.text = name;
        relicDesc.text = desc;
        relicIcon.sprite = icon;
    }
}
