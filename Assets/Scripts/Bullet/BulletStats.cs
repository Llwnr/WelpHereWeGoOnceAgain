using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletStats : MonoBehaviour
{
    public int pierceAmt{get; private set;} = 1;//For bullet to pass through layers

    public void ReducePierceOnHit(){
        pierceAmt--;
    }

    public void SetExtraPiercePower(int amt){
        pierceAmt += amt;
        Debug.Log("Added pierce. New amt: " + pierceAmt);
    }
}
