using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BombExplosionManager : MonoBehaviour
{
    [SerializeField]private float explodeDuration;
    [SerializeField]private GameObject explosion;
    [SerializeField]private float baseExplosionSize;
    private float explosionSize;

    //When you upgrade bombs damage
    private float dmgMultiplier = 1;

    public void SetExplosionStats(float dmgMultiplier, float explosionRange){
        this.dmgMultiplier = dmgMultiplier;
        explosionSize = explosionRange;
    }
    // Update is called once per frame
    void Update()
    {
        explodeDuration-=Time.deltaTime;
        if(explodeDuration <= 0){
            //Set explosion data
            GameObject bombExplosion = Instantiate(explosion, transform.position, Quaternion.identity);

            ISetDamageMultiplier setDamageMultiplier = bombExplosion.GetComponent<ISetDamageMultiplier>();
            setDamageMultiplier.SetDamageMultiplier(dmgMultiplier);

            bombExplosion.transform.localScale = new Vector3(1,1,0) * baseExplosionSize * explosionSize;

            Destroy(gameObject);
        }
    }
}
