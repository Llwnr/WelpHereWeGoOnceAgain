using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlideInAnim : MonoBehaviour
{
    [SerializeField]private Vector2 hiddenPos, targetPos;
    [SerializeField]private float duration, delayDuration;
    
    [SerializeField]private bool playOnEnable;
    
    private void OnEnable() {
        if(playOnEnable) StartSlide();
    }

    void StartSlide(){
        transform.localPosition = hiddenPos;
        StartCoroutine(SlideToTargetPos());
    }

    //Wait for given delay duration then only start sliding. To notify player that the UI is now enabled and game is paused
    IEnumerator SlideToTargetPos(){
        yield return new WaitForSecondsRealtime(delayDuration);
        transform.LeanMoveLocal(targetPos, duration).setIgnoreTimeScale(true).setEaseOutExpo();
    }
}
