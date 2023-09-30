using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightningAnimManager : MonoBehaviour
{
    private float duration=1;
    public void SetDuration(float duration){
        this.duration = duration;
    }

    private void Update() {
        duration -= Time.deltaTime;
        if(duration <= 0){
            GetComponent<Animator>().Play("LightningEnd");
        }
    }
}
