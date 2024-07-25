using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using FMODUnity;
using FMOD.Studio;

public class PlayBGM : MonoBehaviour
{
     public EventReference sfx;
     private EventInstance instance;

    public void Start(){
        instance = RuntimeManager.CreateInstance(sfx);
        instance.start();
    }

    private void OnDestroy() {
        instance.stop(FMOD.Studio.STOP_MODE.IMMEDIATE);
    }
}
