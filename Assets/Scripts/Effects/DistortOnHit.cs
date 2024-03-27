using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DistortOnHit : MonoBehaviour, IWhenDamaged
{
    private HealthManager healthManager;
    [SerializeField]private GameObject distortEffect;

    private void Start() {
        healthManager = GetComponent<HealthManager>();
        healthManager.AddOnDamageListener(this);

        foreach (MonoBehaviour scripts in distortEffect.GetComponents<MonoBehaviour>()) {
            scripts.enabled = false;
        }
    }

    public void WhenDamaged(float dmgAmt, Vector2 hitPoint) {
        //Enable all the distortion effects and post processing on the given game object
        foreach(MonoBehaviour scripts in distortEffect.GetComponents<MonoBehaviour>()) {
            scripts.enabled = true;
        }

        //Also shake player violently
    }
}
