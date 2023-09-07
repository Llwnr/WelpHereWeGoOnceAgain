using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHpManager : MonoBehaviour, IDamagable
{
    [SerializeField]private float maxHp;

    //Manage observers
    private List<IOnDeath> onDeathListeners = new List<IOnDeath>();
    public void AddDeathListener(IOnDeath listener){
        onDeathListeners.Add(listener);
    }
    public void RemoveDeathListener(IOnDeath listener){
        onDeathListeners.Remove(listener);
    }
    public void NotifyDeath(){
        foreach(IOnDeath listener in onDeathListeners){
            listener.OnDeath();
        }
    }

    public void DealDamage(float dmgAmt){
        maxHp -= dmgAmt;
        if(maxHp <= 0){
            Destroy(gameObject);
            NotifyDeath();
        }
    }
}
