using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Y_MoreBullets : RelicSkill
{
    public int numOfExtraBullets;

    public override void Upgrade()
    {
        WeaponManager.instance.IncreaseBulletAmtBy(numOfExtraBullets);
    }
}