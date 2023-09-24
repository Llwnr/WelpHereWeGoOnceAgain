using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class DisplayRemainingBullets : MonoBehaviour
{
    private WeaponManager weaponManager;
    // Start is called before the first frame update
    void Start()
    {
        weaponManager = WeaponManager.instance;
    }

    // Update is called once per frame
    void Update()
    {
        GetComponent<TextMeshProUGUI>().text = weaponManager.GetRemainingBullets().ToString();
    }
}
