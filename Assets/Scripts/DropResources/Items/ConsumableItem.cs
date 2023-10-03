using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class ConsumableItem : MonoBehaviour
{
    //Function that defines what buffs the item will give when consumed by player
    public abstract void ConsumeItem(GameObject consumer);
}
