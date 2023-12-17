using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeathFadeAnim : MonoBehaviour
{
    private Color32 color;
    private float durationToDie = 0.5f;

    private void Start() {
        //Slowly fade & change the sprite color for a death effect
        LeanTween.color(gameObject, Color.black, durationToDie * 0.5f);
        LeanTween.alpha(gameObject, 0.1f, durationToDie * 0.75f);
    }

    private void Update() {
        durationToDie -= Time.deltaTime;
        if (durationToDie <= 0) {
            Destroy(gameObject);
        }

        
    }
}
