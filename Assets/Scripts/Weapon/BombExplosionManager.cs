using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BombExplosionManager : MonoBehaviour, ISetDamageMultiplier
{
    [SerializeField]private float explodeDuration;
    [SerializeField]private GameObject explosion;

    //When you upgrade bombs damage
    private float dmgMultiplier = 1;

    public void SetDamageMultiplier(float dmgMultiplier)
    {
        this.dmgMultiplier = dmgMultiplier;
    }

    // Update is called once per frame
    void Update()
    {
        explodeDuration-=Time.deltaTime;
        if(explodeDuration <= 0){
            //Set damage upgrade info
            ISetDamageMultiplier setDamageMultiplier = Instantiate(explosion, transform.position, Quaternion.identity).GetComponent<ISetDamageMultiplier>();
            setDamageMultiplier.SetDamageMultiplier(dmgMultiplier);
            Destroy(gameObject);
        }
    }
}
