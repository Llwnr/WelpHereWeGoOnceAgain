using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bomber : Relic
{
    public enum BombType{
        YellowBomb,
        SlowBomb
    }
    
    //Bomb stats
    public int NumOfYellowBombs{get; private set;} = 1;
    public float YellowBombDmgMultiplier{get; private set;} = 1;
    public float YBombExplosionRange{get; private set;} = 1;
    public int NumOfSlowBombs{get; private set;} = 1;
    public float SlowBombDmgMultiplier{get; private set;} = 1;
    public float SlowBombExplosionRange{get; private set;} = 1;

    //FOR UPGRADES
    public void IncreaseNumberOfBombs(BombType bombType, int increaseBy){
        switch(bombType){
            case BombType.YellowBomb:
                NumOfYellowBombs += increaseBy;
                break;
            case BombType.SlowBomb:
                NumOfSlowBombs += increaseBy;
                break;
            default:
                Debug.LogError("Given bomb type doesn't exist");
                break;
        }
    }

    public void IncreaseDmgMultiplier(BombType bombType, float increaseBy){
        switch(bombType){
            case BombType.YellowBomb:
                YellowBombDmgMultiplier += increaseBy;
                break;
            case BombType.SlowBomb:
                SlowBombDmgMultiplier += increaseBy;
                break;
            default:
                Debug.LogError("Given bomb type doesn't exist");
                break;
        }
    }

    public void IncreaseExplosionRange(BombType bombType, float increaseBy){
        switch(bombType){
            case BombType.YellowBomb:
                YBombExplosionRange += increaseBy;
                break;
            case BombType.SlowBomb:
                SlowBombExplosionRange += increaseBy;
                break;
            default:
                Debug.LogError("Given bomb type doesn't exist");
                break;
        }
    }

    public int GetNumOfBombs(BombType bombType){
        switch(bombType){
            case BombType.YellowBomb:
                return NumOfYellowBombs;
            case BombType.SlowBomb:
                return NumOfSlowBombs;
        }
        return 0;
    }

    public float GetExplosionRange(BombType bombType){
        switch(bombType){
            case BombType.YellowBomb:
                return YBombExplosionRange;
            case BombType.SlowBomb:
                return SlowBombExplosionRange;
        }
        return 0;
    }

    public float GetDmgMultiplier(BombType bombType){
        switch(bombType){
            case BombType.YellowBomb:
                return YellowBombDmgMultiplier;
            case BombType.SlowBomb:
                return SlowBombDmgMultiplier;
        }
        return 0;
    }
}
