using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SquashStretch : MonoBehaviour
{
    public Vector2 scaleMin, scaleMax;
    public float xOffset, yOffset;
    public float duration;

    private Vector3 origScale;

    private void Start() {
        origScale = transform.localScale;

        StartCoroutine(StartSquishX());
        StartCoroutine(StartSquishY());
    }

    private void Update() {
        transform.localScale = new Vector3(transform.localScale.x, transform.localScale.y, origScale.z);
    }

    //So that vertical squishing and horizontal squishing occurs at different times
    IEnumerator StartSquishX(){
        yield return new WaitForSecondsRealtime(xOffset);
        SquishX();
    }
    IEnumerator StartSquishY(){
        yield return new WaitForSecondsRealtime(yOffset);
        SquishY();
    }

    void SquishX(){
        LeanTween.scaleX(gameObject, scaleMin.x*origScale.x, duration*0.5f).setOnComplete(StretchX).setEaseInOutQuad().setIgnoreTimeScale(true);
    }
    void SquishY(){
        LeanTween.scaleY(gameObject, scaleMin.y*origScale.y, duration*0.5f).setOnComplete(StretchY).setEaseInOutQuad().setIgnoreTimeScale(true);
    }

    void StretchX(){
        LeanTween.scaleX(gameObject, scaleMax.x*origScale.x, duration*0.5f).setOnComplete(SquishX).setEaseInOutQuad().setIgnoreTimeScale(true);
    }
    void StretchY(){
        LeanTween.scaleY(gameObject, scaleMax.y*origScale.y, duration*0.5f).setOnComplete(SquishY).setEaseInOutQuad().setIgnoreTimeScale(true);
    }
}
