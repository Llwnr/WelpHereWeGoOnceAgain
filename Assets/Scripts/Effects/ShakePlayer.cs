using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShakePlayer : MonoBehaviour, IWhenDamaged
{
    public float intensity, frequency, duration, fadeOut;

    public void WhenDamaged(float dmgAmt, Vector2 hitPoint)
    {
        StartShaking();
    }

    void StartShaking(){
        
    }
}
