using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DisplayWin : MonoBehaviour
{
    [SerializeField]private GameObject winImg;
    // Update is called once per frame
    void Update()
    {
        int min, sec;
        TimeManager.GetTimeInMinutes(out min, out sec);

        if(min >= 5){
            winImg.SetActive(true);
            Debug.Log("YOU WONN");
            Time.timeScale = 0;
        }
    }
}
