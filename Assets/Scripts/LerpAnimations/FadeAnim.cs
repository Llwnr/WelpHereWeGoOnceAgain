using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class FadeAnim : MonoBehaviour
{
    [SerializeField]private Color startColor, endColor;
    [SerializeField]private TextMeshProUGUI textBox;
    [SerializeField]private float duration, delay;
    [SerializeField]private bool playOnEnable;//Whether to play the animation when the object is enabled or only when the function is called

    private void Awake() {
        textBox = GetComponent<TextMeshProUGUI>();
    }
    
    private void OnEnable() {
        if(playOnEnable) StartCoroutine(StartFade());
    }

    IEnumerator StartFade(){
        yield return new WaitForSecondsRealtime(delay);
        LeanTween.value(gameObject, updateValueCallback, startColor, endColor, duration);
    }

    //Update the textbox color
    void updateValueCallback(Color val){
        textBox.color = val;
    }


}
