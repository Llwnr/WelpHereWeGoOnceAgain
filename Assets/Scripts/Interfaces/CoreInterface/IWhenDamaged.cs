using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IWhenDamaged
{
    void WhenDamaged(float dmgAmt, Vector2 hitPoint);
}
