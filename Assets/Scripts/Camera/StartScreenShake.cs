using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartScreenShake : MonoBehaviour, IWhenDamaged, IOnAttack
{
    //THIS SCRIPT WILL SCREEN SHAKE BASED ON THE SHAKE CONDITION GIVEN
    public float intensity, frequency, duration, fadeOut;
    //When should the script execute screen shake
    public enum ShakeCondition{
        OnStart,
        OnDestroy,
        OnHit,
        OnAttack
    }
    public ShakeCondition shakeCondition;

    private void Start() {
        //When transform is got hit
        if(CheckCondition(ShakeCondition.OnHit)){
            GetComponent<HealthManager>().AddOnDamageListener(this);
        }
        //When transform attacks/shoots
        if(CheckCondition(ShakeCondition.OnAttack)){
            WeaponManager.instance.AddOnAttackListener(this);
        }
    }

    void ShakeScreen(){
        ScreenShaker.Instance.ShakeScreenOnce(intensity, frequency, duration, fadeOut);
    }

    //Shake screen when transform takes damage
    public void WhenDamaged(float dmgAmt, Vector2 hitPoint)
    {
        if(CheckCondition(ShakeCondition.OnHit)){
            ShakeScreen();
        }
    }

    //Shake screen when gameobject is destroyed
    private void OnDestroy() {
        if(CheckCondition(ShakeCondition.OnDestroy)){
            ShakeScreen();
        }
    }

    //Checks if the condition to shake screen is true or false
    bool CheckCondition(ShakeCondition shakeCondition){
        if(shakeCondition == this.shakeCondition) return true;
        else return false;
    }

    public void OnAttack()
    {
        if(CheckCondition(ShakeCondition.OnAttack)){
            ShakeScreen();
        }
    }
}
