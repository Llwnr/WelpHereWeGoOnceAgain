using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DisplayRelicSelection : MonoBehaviour
{
    [SerializeField]private GameObject relicSelectionUI;

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.X)){
            relicSelectionUI.SetActive(!relicSelectionUI.activeSelf);
            if(relicSelectionUI.activeSelf){
                Time.timeScale = 0;
            }else{
                Time.timeScale = 1;
            }
        }
    }
}
