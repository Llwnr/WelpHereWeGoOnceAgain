using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SquashStretch : MonoBehaviour
{
    public Vector2 scaleMin, scaleMax;
    public float duration;

    private Vector3 origScale;

    private void Start() {
        origScale = transform.localScale;
        Squish();
    }

    private void Update() {
        transform.localScale = new Vector3(transform.localScale.x, transform.localScale.y, origScale.z);
    }

    void Squish(){
        LeanTween.scale(gameObject, scaleMin*origScale, duration*0.5f).setOnComplete(Stretch).setEaseInOutCubic().setIgnoreTimeScale(true);
    }

    void Stretch(){
        LeanTween.scale(gameObject, scaleMax*origScale, duration*0.5f).setOnComplete(Squish).setEaseInOutCubic().setIgnoreTimeScale(true);
    }
}
