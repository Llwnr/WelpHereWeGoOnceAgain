using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using FMOD.Studio;
using FMODUnity;
using UnityEngine.EventSystems;

public class SfxOnHover : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    private EventInstance instance;
    public EventReference sfx;
    
    public void OnPointerEnter(PointerEventData eventData){
        instance = RuntimeManager.CreateInstance(sfx);
        instance.start();
    }

    public void OnPointerExit(PointerEventData eventData){
        instance.stop(FMOD.Studio.STOP_MODE.IMMEDIATE);
    }
}
