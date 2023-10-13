using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayParticleOnHit : MonoBehaviour, IWhenDamaged
{
    [SerializeField]private ParticleSystem particle;
    private HealthManager playerHealthManager;

    public void WhenDamaged(float dmgAmt, Vector2 hitPoint)
    {
        //Play the particle when target is hit
        particle.transform.position = transform.position;
        particle.Play();
    }

    
    // Start is called before the first frame update
    void Start()
    {
        playerHealthManager = GameObject.FindWithTag("Player").GetComponent<HealthManager>();
        playerHealthManager.AddOnDamageListener(this);
        particle.Stop();
    }
}
