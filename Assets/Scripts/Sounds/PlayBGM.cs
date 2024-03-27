using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using FMODUnity;
using FMOD.Studio;

public class PlayBGM : MonoBehaviour
{
     public EventReference sfx;

    public void Awake(){
        RuntimeManager.PlayOneShot(sfx, transform.position);
    }
}
