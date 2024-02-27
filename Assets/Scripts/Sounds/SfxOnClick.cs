using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using FMOD.Studio;
using FMODUnity;

public class SfxOnClick : MonoBehaviour
{
    public EventReference sfx;
    
    private void OnMouseEnter(){
        PlaySound();
    }

    public void PlaySound(){
        RuntimeManager.PlayOneShot(sfx);
    }
}
