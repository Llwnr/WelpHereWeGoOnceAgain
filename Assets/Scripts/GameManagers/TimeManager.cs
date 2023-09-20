using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class TimeManager
{
    public static void GetTimeInMinutes(out int minute, out int second){
        float time = Time.timeSinceLevelLoad;
        minute = Mathf.FloorToInt(time/60);
        second = Mathf.FloorToInt(time%60);
    }
}
