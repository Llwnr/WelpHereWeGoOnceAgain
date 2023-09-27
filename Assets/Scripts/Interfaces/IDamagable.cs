using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IDamagable
{
    void DealDamage(float dmgAmt, Vector2 hitPoint);
}
