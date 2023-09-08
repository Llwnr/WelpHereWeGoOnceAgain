using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectExp : MonoBehaviour
{
    [SerializeField]private float collectRadius;
    [SerializeField]private float attractForce;

    // Update is called once per frame
    void FixedUpdate()
    {
        //Suck all the exp drops in the given radius
        Collider2D[] expPoints = Physics2D.OverlapCircleAll(transform.position, collectRadius);
        foreach (Collider2D expPoint in expPoints){
            if(!expPoint.transform.CompareTag("Exp")) continue;
            expPoint.GetComponent<Rigidbody2D>().AddForce((transform.position-expPoint.transform.position).normalized*attractForce);
        }
    }

    //When it collides with player then consume the exp
    private void OnTriggerEnter2D(Collider2D other) {
        if (other.gameObject.CompareTag("Exp")){
            //Give the exp to player then destroy the point
            if (other.transform.CompareTag("Exp")){
                PlayerLevelManager.AddExp(other.GetComponent<ExpData>().GetExpAmt());
                Destroy(other.gameObject);
            }
        }
    }
}
