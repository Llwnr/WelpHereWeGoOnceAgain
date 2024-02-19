using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class DmgPopup : MonoBehaviour
{
    private TextMeshProUGUI textBox;
    [SerializeField]private float lifeDuration, xMul, yMul, yFlat, xScale, yScale;
    private Vector2 slidePos;

    public void SetDmgAmt(float dmgAmt){
        textBox = GetComponent<TextMeshProUGUI>();
        textBox.text = dmgAmt.ToString("F0");
    }

    public void SetSlideDir(Vector2 dir){
        dir = dir.normalized;
        float yFlatNew = yFlat;
        if(dir.y < 0) yFlatNew = -yFlat;
        //Only for x axis... the popup will always go up in y axis so
        slidePos = new Vector2(dir.x*xMul, dir.y*yMul +yFlatNew) + (Vector2)transform.position;

        //Animate popup
        LeanTween.move(gameObject, slidePos, lifeDuration).setEaseOutBack();
        GetBigger();
    }

    void GetBigger(){
        LeanTween.scale(gameObject, new Vector3(xScale, yScale), lifeDuration*0.3f).setEaseOutCubic().setOnComplete(GetSmaller);
    }

    void GetSmaller(){
        LeanTween.scale(gameObject, new Vector3(1, 1), lifeDuration*0.7f).setEaseOutCubic();
    }


    private void FixedUpdate() {
        lifeDuration -= Time.fixedDeltaTime;
        if(lifeDuration <= 0){
            Destroy(gameObject);
        }
    }
}
