using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExpData : MonoBehaviour
{
    private float expAmtHolded;
    
    public void SetExpAmt(float expAmt){
        expAmtHolded = expAmt;
    }

    public float GetExpAmt(){
        return expAmtHolded;
    }
}
