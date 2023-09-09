using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProcAOE : MonoBehaviour, IOnAttack
{
    [SerializeField]private int bulletShot, bulletShotCounter;

    private void Start() {
        WeaponManager.instance.AddOnAttackListener(this);
        bulletShotCounter = 0;
    }

    public void OnAttack(){
        bulletShotCounter++;
        if(bulletShotCounter == bulletShot){
            bulletShotCounter = 0;
            Debug.Log(bulletShot + "th bullet shot. This one will shoot extra 2 shots");
            StartCoroutine(MultiShot(5));
        }
    }

    IEnumerator MultiShot(int numOfShots){
        yield return new WaitForSeconds(0.1f);
        WeaponManager.instance.ActivateWeapon();
        if(numOfShots > 0){
            StartCoroutine(MultiShot(--numOfShots));
        }
    }
}
