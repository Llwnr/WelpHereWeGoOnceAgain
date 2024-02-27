using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class E_HealEffect : MonoBehaviour
{
    [SerializeField]private ParticleSystem healParticle;
    // Start is called before the first frame update
    void Start()
    {
        healParticle.Stop();
        GetComponent<EnemyHpManager>().AddHealEffect(this);
    }

    private void OnDestroy() {
        GetComponent<EnemyHpManager>().RemoveHealEffect(this);
    }

    public void StartHeal(){
        healParticle.Play();
    }
}
