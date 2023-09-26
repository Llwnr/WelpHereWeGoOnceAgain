using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimeManager : MonoBehaviour
{
    public static TimeManager instance;

    private void Awake() {
        if(instance != null){
            Debug.LogError("More than one time manager");
            return;
        }
        instance = this;
    }
    //For disabled gameobjects to run Update() function for time related stuff such as Time.deltaTime etc
    private List<IRunUpdateFuncEvenWhenDisabled> timeListeners = new List<IRunUpdateFuncEvenWhenDisabled>();
    public void AddTimeListener(IRunUpdateFuncEvenWhenDisabled listener){
        timeListeners.Add(listener);
    }

    public void RemoveTimeListener(IRunUpdateFuncEvenWhenDisabled listener){
        timeListeners.Remove(listener);
    }

    void NotifyTimeListeners(){
        foreach(IRunUpdateFuncEvenWhenDisabled listener in timeListeners){
            listener.RunUpdate();
        }
    }

    private void Update() {
        NotifyTimeListeners();
    }


    public static void GetTimeInMinutes(out int minute, out int second){
        float time = Time.timeSinceLevelLoad;
        minute = Mathf.FloorToInt(time/60);
        second = Mathf.FloorToInt(time%60);
    }


}
