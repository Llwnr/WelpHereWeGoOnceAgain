using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(RelicSkillManager))]
public class SetTickMark : MonoBehaviour
{
    private RelicSkillManager relicState;
    [SerializeField]private GameObject tickmarkBox;

    private void Awake() {
        relicState = GetComponent<RelicSkillManager>();
    }

    private void OnEnable() {
        //Set the tickmark image if the skill is already unlocked
        if(relicState.isUnlocked){
            tickmarkBox.SetActive(true);
        }else{
            tickmarkBox.SetActive(false);
        }
    }
}
