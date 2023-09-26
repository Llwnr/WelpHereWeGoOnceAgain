using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class RelicSkillDataDisplay : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    [SerializeField]private Transform infoBox;
    [SerializeField]private TextMeshProUGUI nameBox, descBox;
    [SerializeField]private float waitToDisplay;
    private float displayTimer;

    private RelicSkillManager myRelicSkill;

    private bool isHovering;

    //Hover effect.. show upgrade icon's data i.e. what the skill does
    public void OnPointerEnter(PointerEventData eventData)
    {
        isHovering = true;
    }

    private void Update() {
        //Display info when player hovers for a while
        if(isHovering){
            displayTimer -= Time.unscaledDeltaTime;
            if(displayTimer <= 0){
                DisplayUpgradeInfo();
            }
        }
    }

    void DisplayUpgradeInfo(){
        infoBox.gameObject.SetActive(true);
        //Set data of the skill/relic upgrader
        infoBox.transform.position = Input.mousePosition + new Vector3(400,0);
        nameBox.text = myRelicSkill.name;
        descBox.text = myRelicSkill.description;
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        isHovering = false;
        //Stop displaying info
        ResetDisplayTimer();
        infoBox.gameObject.SetActive(false);
    }

    // Start is called before the first frame update
    void Start()
    {
        myRelicSkill = GetComponent<RelicSkillManager>();
        GetComponent<Image>().sprite = myRelicSkill.icon;
        ResetDisplayTimer();
    }

    void ResetDisplayTimer(){
        displayTimer = waitToDisplay;
    }
}
