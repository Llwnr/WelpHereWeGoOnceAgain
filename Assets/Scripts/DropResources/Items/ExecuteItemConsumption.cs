using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//This class manages item consumption buffs
public class ExecuteItemConsumption : MonoBehaviour
{
    private ConsumableItem consumableItem;
    private void Start() {
        consumableItem = GetComponent<ConsumableItem>();
    }

    private void OnTriggerEnter2D(Collider2D other) {
        if(other.transform.CompareTag("Player")){
            consumableItem.ConsumeItem(other.gameObject);
            Destroy(gameObject);
        }
    }
}
