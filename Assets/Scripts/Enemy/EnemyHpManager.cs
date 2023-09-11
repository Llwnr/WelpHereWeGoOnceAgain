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
    //To notify when player has been damaged
    private List<IWhenDamaged> onDamageListeners = new List<IWhenDamaged>();
    public void AddOnDamageListener(IWhenDamaged damageListener){
        onDamageListeners.Add(damageListener);
    }
    public void RemoveOnDamageListener(IWhenDamaged damageListener){
        onDamageListeners.Remove(damageListener);
    }
    void NotifyWhenDamaged(float dmgAmt){
        foreach(IWhenDamaged damageListener in onDamageListeners){
            damageListener.WhenDamaged(dmgAmt);
        }
    }

    public void DealDamage(float dmgAmt){
        maxHp -= dmgAmt;
        NotifyWhenDamaged(dmgAmt);
        if(maxHp <= 0){
            Destroy(gameObject);
            NotifyDeath();
        }
    }
}
