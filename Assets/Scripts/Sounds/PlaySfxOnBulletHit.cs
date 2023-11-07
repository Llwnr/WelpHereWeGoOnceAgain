using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using FMODUnity;
using FMOD.Studio;

public class PlaySfxOnBulletHit : MonoBehaviour
{
    public EventReference sfx;

    private int dontPlaySound = 2;//Number of frames to not play sound since when player shoots bullet it collides with player himself

    private void FixedUpdate() {
        dontPlaySound--;
    }

    private void OnTriggerEnter2D(Collider2D other) {
        if(dontPlaySound > 0) return;
        if(other.transform.CompareTag("Player") || other.transform.CompareTag("Enemy")){
            RuntimeManager.PlayOneShot(sfx, transform.position);
        }
    }
}
