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

    List<ISetDamageMultiplier> setDamageMultipliers = new List<ISetDamageMultiplier>();

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

            //Get the script to set dmg multipliers in case the relic's dmg is upgraded
            if(newBomb.GetComponent<ISetDamageMultiplier>() != null){
                //Store all dmg upgradable script
                foreach(ISetDamageMultiplier setDamageMultiplier in newBomb.GetComponents<ISetDamageMultiplier>()){
                    this.setDamageMultipliers.Add(setDamageMultiplier);
                }
                UpdateRelicUpgrades();
            }
        }
    }

    public override void UpdateRelicUpgrades(){
        //Increase damage
        foreach(ISetDamageMultiplier damageMultiplier in setDamageMultipliers){
            damageMultiplier.SetDamageMultiplier(dmgMultiplier);
        }
    }

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
}
