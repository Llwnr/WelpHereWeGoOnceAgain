using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlideInAnim : MonoBehaviour
{
    [SerializeField]private Vector2 origPos, targetPos;
    [SerializeField]private float duration = 1f, delayDuration = 0f;
    
    private void OnEnable() {
        transform.localPosition = origPos;

        StartCoroutine(SlideToTargetPos());
    }

    //Wait for given delay duration then only start sliding. To notify player that the UI is now enabled and game is paused
    IEnumerator SlideToTargetPos(){
        yield return new WaitForSecondsRealtime(delayDuration);
        transform.LeanMoveLocal(targetPos, duration).setIgnoreTimeScale(true).setEaseOutExpo();
    }
}
