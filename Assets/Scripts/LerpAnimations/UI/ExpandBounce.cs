using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class ExpandBounce : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    public Vector2 scaleMax;
    public float duration;

    private Vector3 origScale;

    public AnimationCurve easing;

    private void Start() {
        origScale = transform.localScale;
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        StartExpandAnim();
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        RevertToOrigScale();
    }
    //This will start expanding the object
    void StartExpandAnim(){
        LeanTween.cancel(gameObject);
        LeanTween.scale(gameObject, (Vector3)(scaleMax*origScale) + new Vector3(0,0, origScale.z), duration).setEase(easing).setIgnoreTimeScale(true);
    }

    //This will smoothly revert object to original size
    void RevertToOrigScale(){
        LeanTween.cancel(gameObject);
        LeanTween.scale(gameObject, origScale, duration*0.4f).setEaseInExpo().setIgnoreTimeScale(true);
    }


    
}
