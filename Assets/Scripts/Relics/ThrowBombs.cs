using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class ThrowBombs : ShotCounterBasedRelic, IOnAttack, ISetDamageMultiplier
{
    [SerializeField]private float range;
    [SerializeField]private int numOfBombs;
    [SerializeField]private GameObject bomb;

    //Manage upgrades
    private float dmgMultiplier = 1;
    private float explosionRange = 8;

    public override void OnAttack(){
        base.OnAttack();
    }
    public override void ActivateSkill(){
        //Throw bombs at random direction
        for(int i=0; i<numOfBombs; i++){
            Ray2D ray = new Ray2D(player.transform.position, Random.onUnitSphere);
            Vector2 bombPos = ray.GetPoint(range);

            //Give info on where the bomb should land
            GameObject newBomb = Instantiate(bomb, player.transform.position, Quaternion.identity);
            ThrowManager throwManager = newBomb.GetComponent<ThrowManager>();
            throwManager.SetDestination(bombPos);

            //Give bomb stats such as explosion range and dmg buff
            newBomb.GetComponent<BombExplosionManager>().SetExplosionStats(dmgMultiplier, explosionRange);
        }
    }

    //UPGRADES ARE DONE FROM FOLLOWING FUNCTIONS
    public void SetDamageMultiplier(float dmgMultiplier)
    {
        this.dmgMultiplier = dmgMultiplier;
        UpdateRelicUpgrades();
    }

    public float GetDamageMultiplier(){
        return dmgMultiplier;
    }

    public void IncreaseNumberOfBombsBy(int amt){
        numOfBombs += amt;
    }

    public void IncreaseExplosionRange(float byAmt){
        explosionRange += byAmt;
    }
}
