using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item_Health : ConsumableItem
{
    public int healAmt;
    public override void ConsumeItem(GameObject consumer)
    {
        consumer.GetComponent<HealthManager>().Heal(healAmt);
    }
}
