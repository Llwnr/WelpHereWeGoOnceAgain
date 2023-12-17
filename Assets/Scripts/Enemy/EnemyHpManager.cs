using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHpManager : MonoBehaviour, IDamagable
{
    [SerializeField]private float maxHp;
    private float currHp;

    private Collider2D col;
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
    void NotifyWhenDamaged(float dmgAmt, Vector2 hitPoint){
        foreach(IWhenDamaged damageListener in onDamageListeners){
            damageListener.WhenDamaged(dmgAmt, hitPoint);
        }
    }

    private void Start() {
        currHp = maxHp;
        col = GetComponent<Collider2D>();
    }

    public void DealDamage(float dmgAmt, Vector2 hitPoint){
        currHp -= dmgAmt;
        NotifyWhenDamaged(dmgAmt, hitPoint);
        if(currHp <= 0){
            //Wait for knockback then die
            GetComponent<Collider2D>().enabled = false;
            StartCoroutine(DestroyAfterKnockback());
        }
    }

    IEnumerator DestroyAfterKnockback() {
        yield return new WaitForSeconds(0.2f);
        Destroy(gameObject);
        NotifyDeath();
    }

    public void Heal(float amt){
        currHp += amt;
        if(currHp > maxHp) currHp = maxHp;
    }

    public void GetHpData(out int currentHp, out int maxHp){
        currentHp = (int)currHp;
        maxHp = (int)this.maxHp;
    }
}
