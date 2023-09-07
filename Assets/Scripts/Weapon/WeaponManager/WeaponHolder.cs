﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponHolder : MonoBehaviour
{
    [SerializeField]private WeaponBase equippedWeapon;

    public WeaponBase GetEquippedWeapon(){
        return equippedWeapon;
    }
}
