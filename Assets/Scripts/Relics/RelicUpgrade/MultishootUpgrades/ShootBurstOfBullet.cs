using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootBurstOfBullet : ShotCounterBasedRelicSkill, IOnReload
{
    [SerializeField]private int numOfExtraShots;
    [SerializeField]private GameObject bullet;
    [SerializeField]private float shotSpeed;

    private MultiShoot multiShootInfo;

    //Only activate skill once per reload
    private bool canActivate = true;
    public override void Upgrade()
    {
        multiShootInfo = relicManager.GetComponent<MultiShoot>();

        bulletShotCounter = 0;
        player = GameObject.FindWithTag("Player");
        //Subscribe to know how many bullets have been shot and when player reloads
        WeaponManager.instance.AddOnReloadListener(this);
        WeaponManager.instance.AddOnAttackListener(this);
    }

    public void OnReloadStart(){
        canActivate = true;
        bulletShotCounter = 0;
    }

    public void OnReloadComplete(){
        
    }

    protected override void ActivateSkill()
    {
        if(!canActivate) return;

        MultiShot(numOfExtraShots+multiShootInfo.extraShots);
        canActivate = false;
    }

    void MultiShot(int numOfShots){
        //Spread shot like shotgun
        float angle = 0;
        float spreadAngle = multiShootInfo.spreadAngle;
        for(int i=0; i<numOfShots; i++){
            int iDivisor = numOfShots/2;
            angle = (i-iDivisor)*spreadAngle;
            GameObject myBullet = WeaponManager.instance.ActivateWeapon(angle, bullet, 1+multiShootInfo.dmgMultiplier, shotSpeed);
            //Give bullet info
            myBullet.GetComponent<BulletStats>().SetExtraPiercePower(multiShootInfo.extraPiercePower);
        }
    }
}
