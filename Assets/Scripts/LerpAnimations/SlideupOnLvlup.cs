using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlideupOnLvlup : MonoBehaviour, IOnLevelUp
{
    [SerializeField]private float targetPosY;
    private Vector2 origLocalPosY;
    [SerializeField]private float duration;

    private void Start() {
        gameObject.SetActive(false);
        PlayerLevelManager.AddLevelupListener(this);
        origLocalPosY = transform.localPosition;
    }

    private void OnDestroy() {
        PlayerLevelManager.RemoveLevelupListener(this);
    }

    public void OnLevelUp()
    {
        gameObject.SetActive(true);
        LeanTween.moveLocalY(gameObject, targetPosY, duration).setIgnoreTimeScale(true).setOnComplete(ResetLocalPos).setEaseOutExpo();
    }

    //Reset position and hide
    void ResetLocalPos(){
        transform.localPosition = origLocalPosY;
        gameObject.SetActive(false);
    }
}
