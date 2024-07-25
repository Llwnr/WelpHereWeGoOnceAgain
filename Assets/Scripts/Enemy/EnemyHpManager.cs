using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHpManager : MonoBehaviour, IDamagable
{
    [SerializeField]private float maxHp;

    private float currHp;

    private Collider2D col;
    public bool alreadyDead = false;
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

    private List<E_HealEffect> healEffects = new List<E_HealEffect>();
    public void AddHealEffect(E_HealEffect healEffect){
        healEffects.Add(healEffect);
    }
    public void RemoveHealEffect(E_HealEffect healEffect){
        healEffects.Remove(healEffect);
    }
    void StartHealEffect(){
        foreach(E_HealEffect healEffect in healEffects){
            healEffect.StartHeal();
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
            alreadyDead = true;
            //Wait for knockback then die
            GetComponent<Collider2D>().enabled = false;
            StartCoroutine(DestroyAfterKnockback());
        }
    }

    IEnumerator DestroyAfterKnockback() {
        yield return new WaitForSeconds(0.1f);
        Destroy(gameObject);
        NotifyDeath();
    }

    public void Heal(float amt){
        currHp += amt;
        if(currHp > maxHp) currHp = maxHp;
        StartHealEffect();
    }

    public void GetHpData(out int currentHp, out int maxHp){
        currentHp = (int)currHp;
        maxHp = (int)this.maxHp;
    }
}
