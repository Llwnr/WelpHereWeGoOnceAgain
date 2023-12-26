using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeathFadeAnim : MonoBehaviour
{
    private Color32 color;
    [SerializeField]private float durationToDie = 0.5f;

    private void Start() {
        //Slowly fade & change the sprite color for a death effect
        LeanTween.color(gameObject, Color.red, durationToDie * 0.4f);
        LeanTween.alpha(gameObject, 0.25f, durationToDie * 0.7f);
    }

    private void Update() {
        durationToDie -= Time.deltaTime;
        if (durationToDie <= 0) {
            Destroy(gameObject);
        }

        
    }
}
