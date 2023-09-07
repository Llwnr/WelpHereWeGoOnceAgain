using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class PlayerLevelManager
{
    private static float expAmt = 0;
    private static int level = 1;
    
    public static void AddExp(float expGained){
        expAmt += expGained;

        //After gaining exp see if you can level up. If so, level up
        UpdateLevelBasedOnExp();

        void UpdateLevelBasedOnExp(){
            level = Mathf.FloorToInt(expAmt);
            Debug.Log("New level: " + level);
        }
    }
}
