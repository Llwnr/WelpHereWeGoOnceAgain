using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Expand : CommonFuncExecutor
{
    public Vector3 startScale, endScale;
    public float duration;

    public AnimationCurve easing;

    private Vector3 origScale;

    private void Awake() {
        origScale = transform.localScale;
    }

    public override void FuncToRun()
    {
        transform.localScale = startScale;
        LeanTween.scale(gameObject, endScale, duration).setIgnoreTimeScale(true);
    }
}
