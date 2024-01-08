using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeathFadeAnim : MonoBehaviour
{
    [SerializeField]private Color32 color;
    [SerializeField]private float durationToDie = 0.5f, finalAlpha, alphaDuration;

    private void Start() {
        //Slowly fade & change the sprite color for a death effect
        LeanTween.color(gameObject, color, alphaDuration);
        LeanTween.alpha(gameObject, finalAlpha, alphaDuration);
    }

    private void Update() {
        durationToDie -= Time.deltaTime;
        if (durationToDie <= 0) {
            Destroy(gameObject);
        }

        
    }
}
