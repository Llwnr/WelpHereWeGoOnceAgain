using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletLife : MonoBehaviour
{
    [SerializeField]private float lifeDuration = 1f;

    // Update is called once per frame
    void Update()
    {
        lifeDuration -= Time.deltaTime;
        if(lifeDuration <= 0){
            Destroy(gameObject);
        }
    }
}
