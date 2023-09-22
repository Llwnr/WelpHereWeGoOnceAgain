using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DisplaySkillTree : MonoBehaviour
{
    [SerializeField]private GameObject skillTreeHolder;

    public void DisplaySkillTreeOfRelicType(RelicType.RelicTypes relicType){
        Time.timeScale = 0;
        foreach(RelicType skillTreeRelicType in skillTreeHolder.GetComponentsInChildren<RelicType>(true)){
            //Enable the relic skill tree if it is of same type as selected relic
            if(skillTreeRelicType.GetRelicType() == relicType){
                skillTreeRelicType.gameObject.SetActive(true);
                Debug.Log(skillTreeRelicType);
            }
        }
    }

    //When purchasing any skill upgrade from skill tree, disable all skill tree so that 1 upgrade per level
    private void OnDisable() {
        foreach(RelicType skillTreeRelicType in GetComponentsInChildren<RelicType>()){
            skillTreeRelicType.gameObject.SetActive(false);
        }
        Time.timeScale = 1;
    }
}
