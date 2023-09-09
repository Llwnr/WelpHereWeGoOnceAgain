using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThrowBombs : ShotCounterBasedRelic, IOnAttack
{
    [SerializeField]private float range;
    [SerializeField]private int numOfBombs;
    [SerializeField]private GameObject bomb;

    public override void OnAttack(){
        base.OnAttack();
    }
    public override void ActivateSkill(){
        //Throw bombs at random direction
        for(int i=0; i<numOfBombs; i++){
            Ray2D ray = new Ray2D(transform.position, Random.onUnitSphere);
            Vector2 bombPos = ray.GetPoint(range);

            //Give info on where the bomb should land
            ThrowManager throwManager = Instantiate(bomb, transform.position, Quaternion.identity).GetComponent<ThrowManager>();
            throwManager.SetDestination(bombPos);
        }
        Debug.Log("Threw some bombs");
    }
}
