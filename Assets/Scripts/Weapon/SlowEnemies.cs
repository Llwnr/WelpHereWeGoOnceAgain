using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlowEnemies : MonoBehaviour
{
    [SerializeField]private float slowAmtOutOfHundred;
    [SerializeField]private float slowDuration;

    private void OnTriggerEnter2D(Collider2D other) {
        if(other.transform.CompareTag("Enemy")){
            other.GetComponent<MoveTowardsPlayer>().SetMovespeedMultiplier(1-slowAmtOutOfHundred/100f, slowDuration);
        }
    }
}
