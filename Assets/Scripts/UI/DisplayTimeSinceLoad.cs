using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class DisplayTimeSinceLoad : MonoBehaviour
{
    [SerializeField]private TextMeshProUGUI minuteBox, secondBox;
    private int minute, second;

    // Update is called once per frame
    void Update()
    {
        TimeManager.GetTimeInMinutes(out minute, out second);
        //For displaying minutes and seconds since the game has run
        if(minute < 10) minuteBox.text = "0";
        else minuteBox.text = "";
        minuteBox.text += minute.ToString();

        if(second < 10) secondBox.text = "0";
        else secondBox.text = "";
        secondBox.text += second.ToString();
    }
}
