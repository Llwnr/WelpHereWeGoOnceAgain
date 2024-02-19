using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreateDeathEffect : MonoBehaviour, IOnDeath
{
    private EnemyHpManager hpManager;
    [SerializeField]private GameObject deathParticle;
    private void Start() {
        hpManager = GetComponent<EnemyHpManager>();
        hpManager.AddDeathListener(this);
    }

    public void OnDeath() {
        //Create death particle effect
        GameObject deathEffect = Instantiate(deathParticle, transform.position, Quaternion.identity);
        deathEffect.GetComponent<SpriteRenderer>().sprite = GetComponent<SpriteRenderer>().sprite;
        deathEffect.GetComponent<SpriteRenderer>().material = GetComponent<SpriteRenderer>().material;
        deathEffect.transform.eulerAngles = transform.localEulerAngles;
    }
}
