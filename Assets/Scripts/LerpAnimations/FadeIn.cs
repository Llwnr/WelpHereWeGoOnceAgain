using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class FadeIn : CommonFuncExecutor
{
    public float startAlpha, endAlpha, duration;

    private CanvasGroup canvasGroup;

    public AnimationCurve easing;

    private void Awake() {
        canvasGroup = GetComponent<CanvasGroup>();
    }

    public override void FuncToRun()
    {
        canvasGroup.alpha = startAlpha;
        LeanTween.value(gameObject, AlphaChanger, startAlpha, endAlpha, duration).setIgnoreTimeScale(true).setEase(easing);
    }

    void AlphaChanger(float myAlpha){
        canvasGroup.alpha = myAlpha;
    }
}
