using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class PlayerLevelManager
{
    public static float expForNextLevel{get; private set;} = 5;
    private static float expThresholdIncrease = 2;
    public static float expAmt{get; private set;} = 0;
    private static int level = 1;

    //Observers for when player levels up
    private static List<IOnLevelUp> levelUpListeners = new List<IOnLevelUp>();
    public static void AddLevelupListener(IOnLevelUp listener){
        levelUpListeners.Add(listener);
    }
    public static void RemoveLevelupListener(IOnLevelUp listener){
        levelUpListeners.Remove(listener);
    }
    static void NotifyLevelUp(){
        foreach(IOnLevelUp listener in levelUpListeners){
            listener.OnLevelUp();
        }
    }
    
    public static void AddExp(float expGained){
        expAmt += expGained;

        //After gaining exp see if you can level up. If so, level up
        UpdateLevelBasedOnExp();

        void UpdateLevelBasedOnExp(){
            if(expAmt >= expForNextLevel){
                expAmt = 0;
                //Increase exp required to reach next level
                expForNextLevel += expThresholdIncrease;

                //Also increase level
                level++;
                Debug.Log("Level increased. Stats are slightly buffed and you can pick an upgrade");

                //Notify that player has leveled up
                NotifyLevelUp();
            }
        }
    }
}
