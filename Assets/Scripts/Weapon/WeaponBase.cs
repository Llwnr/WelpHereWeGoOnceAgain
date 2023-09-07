using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "WeaponBase", menuName = "WelpHereWeGoOnceAgain/WeaponBase", order = 0)]
public class WeaponBase : ScriptableObject {
    //Basic weapon info
    public new string name;
    public string description;

    public GameObject bullet;

    //All of these are base data i.e. before being affected by upgrades such as increase max num of bullets, faster reload speed etc
    public int maxNumOfBullets;
    public float atkSpeed; //Speed of time interval of shooting bullet "1" atkspeed = 1 bullet shot per second
    public float atkPower;
    public float reloadTime;
    public float shootForce;
    
}

