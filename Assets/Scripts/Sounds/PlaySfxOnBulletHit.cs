using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using FMODUnity;
using FMOD.Studio;

public class PlaySfxOnBulletHit : MonoBehaviour
{
    public EventReference sfx;

    private void OnTriggerEnter2D(Collider2D other) {
        if(other.transform.CompareTag("Enemy")){
            RuntimeManager.PlayOneShot(sfx, transform.position);
        }
    }
}
