using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DisplayInjured : MonoBehaviour, IWhenDamaged
{
    [SerializeField]private Color32 injuredColor;
    private Color32 origColor;
    [SerializeField]private float switchDuration;
    [SerializeField]private EnemyHpManager enemyHpManager;

    private void Start() {
        //Subscribe to know when this enemy is damaged
        enemyHpManager.AddOnDamageListener(this);

        origColor = GetComponent<SpriteRenderer>().color;
    }

    public void WhenDamaged(float dmgAmt, Vector2 hitPoint)
    {
        GetComponent<SpriteRenderer>().color = injuredColor;
        StartCoroutine(ReturnToNormalColor());
    }

    IEnumerator ReturnToNormalColor(){
        float lerpValue = 0;
        while(GetComponent<SpriteRenderer>().color != origColor){
            lerpValue += Time.deltaTime;
            //Smoothly transition to original color
            GetComponent<SpriteRenderer>().color = Color32.Lerp(injuredColor, origColor, lerpValue/switchDuration);
            yield return null;
        }
    }
}
