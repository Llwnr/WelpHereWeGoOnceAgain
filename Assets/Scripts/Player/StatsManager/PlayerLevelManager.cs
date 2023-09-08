using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class PlayerLevelManager
{
    public static float expForNextLevel{get; private set;} = 5;
    private static float expThresholdIncrease = 2;
    public static float expAmt{get; private set;} = 0;
    private static int level = 1;
    
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
            }
        }
    }
}
