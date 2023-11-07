using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthManager : MonoBehaviour, IDamagable
{
    private PlayerBasicStats playerStats;
    private int currHp, maxHp, prevMaxHp;

    private DashManager dashManager;

    //To notify when player has been damaged
    private List<IWhenDamaged> onDamageListeners = new List<IWhenDamaged>();
    public void AddOnDamageListener(IWhenDamaged damageListener){
        onDamageListeners.Add(damageListener);
    }
    public void RemoveOnDamageListener(IWhenDamaged damageListener){
        onDamageListeners.Remove(damageListener);
    }
    void NotifyWhenDamaged(float dmgAmt, Vector2 hitPoint){
        foreach(IWhenDamaged damageListener in onDamageListeners){
            damageListener.WhenDamaged(dmgAmt, hitPoint);
        }
    }

    private void Start() {
        dashManager = GetComponent<DashManager>();
        playerStats = GetComponent<PlayerBasicStats>();
        currHp = playerStats.GetMaxHp();
        maxHp = playerStats.GetMaxHp();
        prevMaxHp = maxHp;
    }

    private void Update() {
        maxHp = playerStats.GetMaxHp();
        //Increase current hp when max hp increases
        if(maxHp > prevMaxHp){
            currHp += maxHp - prevMaxHp;
            prevMaxHp = maxHp;
        }
    }

    public void DealDamage(float dmgAmt, Vector2 hitPoint){
        //Make player immune to damage when dashing
        if(dashManager.GetPlayerDashing()) return;
        currHp -= (int)dmgAmt;
        //Notify that player has been damaged
        NotifyWhenDamaged(dmgAmt, hitPoint);

        if(currHp <= 0){
            Destroy(gameObject);
        }
    }

    public void GetHpData(out int currHp, out int maxHp){
        currHp = this.currHp;
        maxHp = this.maxHp;
    }

    public void Heal(int amt){
        currHp += amt;
        if(currHp > maxHp) currHp = maxHp;
    }
}
