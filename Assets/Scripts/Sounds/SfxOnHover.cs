using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using FMODUnity;
using UnityEngine.EventSystems;

public class SfxOnHover : MonoBehaviour, IPointerEnterHandler
{
    public EventReference sfx;
    
    public void OnPointerEnter(PointerEventData eventData){
        RuntimeManager.PlayOneShot(sfx);
    }
}
