using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using FMODUnity;
using FMOD.Studio;

public class PlaySfxOnShoot : MonoBehaviour, IOnAttack
{
    public EventReference sfx;

    private void Start() {
        WeaponManager.instance.AddOnAttackListener(this);
    }

    public void OnAttack()
    {
        RuntimeManager.PlayOneShot(sfx, transform.position);
    }
}
