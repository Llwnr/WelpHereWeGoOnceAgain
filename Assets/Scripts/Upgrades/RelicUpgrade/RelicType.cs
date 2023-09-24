using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RelicType : MonoBehaviour
{
    public enum RelicTypes{
        greenBomb,
        yellowBomb,
        redBomb,
        blueSlowBomb,
        multiShoot
    }
    [SerializeField]private RelicTypes myRelicType;
    public RelicTypes GetRelicType(){
        return myRelicType;
    }
}
