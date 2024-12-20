using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LifeDuration : MonoBehaviour
{
    [SerializeField]private float duration;
    private void Update() {
        duration -= Time.deltaTime;
        if(duration <= 0) Destroy(gameObject);
    }
}
