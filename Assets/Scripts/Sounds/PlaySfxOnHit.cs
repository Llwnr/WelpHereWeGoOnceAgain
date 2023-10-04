using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using FMODUnity;
using FMOD.Studio;

public class PlaySfxOnHit : MonoBehaviour, IWhenDamaged
{
    public EventReference sfx;

    private void Start() {
        GetComponent<EnemyHpManager>().AddOnDamageListener(this);
    }

    public void WhenDamaged(float dmgAmt, Vector2 dir)
    {
        RuntimeManager.PlayOneShot(sfx, dir);
    }
}
