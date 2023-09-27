using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class ThrowBombs : ShotCounterBasedRelicSkill
{
    private Bomber myBomberRelic;
    [SerializeField]private float range;
    [SerializeField]private int numOfBombs;
    [SerializeField]private GameObject bomb;

    [SerializeField]private Bomber.BombType bombType;

    //Manage upgrades
    private float dmgMultiplier = 1;
    private float explosionRange = 8;

    private int finalNumOfBombs;
    private float finalDmgMultiplier, finalExplosionRange;

    public override void Upgrade()
    {
        base.Upgrade();
        myBomberRelic = relicManager.GetComponent<Bomber>();
    }

    protected override void ActivateSkill(){
        GetBombStats();
        //Throw bombs at random direction
        for(int i=0; i<finalNumOfBombs; i++){
            Ray2D ray = new Ray2D(player.transform.position, Random.onUnitSphere);
            Vector2 bombPos = ray.GetPoint(range);

            //Give info on where the bomb should land
            GameObject newBomb = Instantiate(bomb, player.transform.position, Quaternion.identity);
            ThrowManager throwManager = newBomb.GetComponent<ThrowManager>();
            throwManager.SetDestination(bombPos+bombPos*Random.Range(-0.15f, 0.15f));

            //Give bomb stats such as explosion range and dmg buff
            newBomb.GetComponent<BombExplosionManager>().SetExplosionStats(finalDmgMultiplier, finalExplosionRange);
        }
    }

    private void GetBombStats(){
        //Update the stats such as 
        finalNumOfBombs = numOfBombs+myBomberRelic.GetNumOfBombs(bombType);
        finalDmgMultiplier = dmgMultiplier+myBomberRelic.GetDmgMultiplier(bombType);
        finalExplosionRange = explosionRange+myBomberRelic.GetExplosionRange(bombType);
    }
}
