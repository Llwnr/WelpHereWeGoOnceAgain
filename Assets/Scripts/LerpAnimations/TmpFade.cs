using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class TmpFade : MonoBehaviour, IOnLevelUp
{
    public TextMeshProUGUI textBox;
    public float startAlpha, endAlpha, delayDuration, lerpDuration;

    private Color textBoxColor;

    private void Awake() {
        PlayerLevelManager.AddLevelupListener(this);
        textBox = GetComponent<TextMeshProUGUI>();
        textBoxColor = textBox.color;
    }

    private void OnDestroy() {
        PlayerLevelManager.RemoveLevelupListener(this);
    }

    public void OnLevelUp()
    {
        textBox.color = new Color(textBoxColor.r, textBoxColor.g, textBoxColor.b, startAlpha);
        gameObject.SetActive(true);
        StartCoroutine(ExecuteFade());
    }

    IEnumerator ExecuteFade(){
        yield return new WaitForSecondsRealtime(delayDuration);

        LeanTween.value(gameObject, AlphaChanger, startAlpha, endAlpha, lerpDuration).setIgnoreTimeScale(true);
    }

    //Change alpha as the lerp function sends the alpha values
    void AlphaChanger(float myAlpha){
        textBox.color = new Color(textBoxColor.r, textBoxColor.g, textBoxColor.b, myAlpha);
    }
}
