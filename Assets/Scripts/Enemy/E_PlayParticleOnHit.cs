using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class E_PlayParticleOnHit : MonoBehaviour, IWhenDamaged
{
    [SerializeField]private ParticleSystem hitEffect;
    private void Start() {
        GetComponent<EnemyHpManager>().AddOnDamageListener(this);
        hitEffect.Stop();
    }

    public void WhenDamaged(float dmgAmt, Vector2 hitPoint)
    {
        //Get Angle for the particle to splatter in the correct direction i.e. opposite of bullet hit
        Vector2 dir = transform.position - GameObject.FindWithTag("Player").transform.position;
        float angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg - 90;

        ParticleSystem newHitEffect = Instantiate(hitEffect, transform.position, Quaternion.identity);
        newHitEffect.transform.eulerAngles = new Vector3(0,0, angle);
        newHitEffect.transform.parent = null;
        newHitEffect.Play();
        Destroy(newHitEffect.gameObject, 0.7f);
    }
}
