using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RelicType : MonoBehaviour
{
    public enum RelicTypes{
        bomb,
        multiShoot,
        lightning
    }
    [SerializeField]private RelicTypes myRelicType;
    public RelicTypes GetRelicType(){
        return myRelicType;
    }
}
