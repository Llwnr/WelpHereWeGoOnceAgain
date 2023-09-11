using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class DmgPopup : MonoBehaviour
{
    private TextMeshProUGUI textBox;
    [SerializeField]private float lifeDuration;
    private float lifeDurationCounter;
    private Vector2 slideDir;

    public void SetDmgAmt(float dmgAmt){
        textBox = GetComponent<TextMeshProUGUI>();
        textBox.text = dmgAmt.ToString("F0");
    }

    public void SetSlideDir(Vector2 dir){
        dir = dir.normalized;
        //Only for x axis... the popup will always go up in y axis so
        slideDir = new Vector2(dir.x, 0.5f)+(Vector2)transform.position;
    }

    private void Start() {
        lifeDurationCounter = lifeDuration;
    }

    private void FixedUpdate() {
        lifeDurationCounter -= Time.fixedDeltaTime;
        if(lifeDurationCounter <= 0){
            Destroy(gameObject);
        }

        //Animate popup
        transform.position = Vector2.Lerp(transform.position, slideDir, 1-lifeDurationCounter/lifeDuration);
    }
}
