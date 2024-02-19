using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using FMOD.Studio;
using FMODUnity;

public class SfxOnExpCollect : MonoBehaviour
{
    public EventReference sfx;
    
    void OnDestroy(){
        RuntimeManager.PlayOneShot(sfx);
    }
}
