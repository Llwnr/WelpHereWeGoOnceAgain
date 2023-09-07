using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectExp : MonoBehaviour
{
    [SerializeField]private float collectRadius;

    // Update is called once per frame
    void FixedUpdate()
    {
        //Get all the exp drops in the given radius
        Collider2D[] expPoints = Physics2D.OverlapCircleAll(transform.position, collectRadius);
        foreach (Collider2D expPoint in expPoints){
            //Give the exp to player then destroy the point
            if (expPoint.transform.CompareTag("Exp")){
                PlayerLevelManager.AddExp(expPoint.GetComponent<ExpData>().GetExpAmt());
                Destroy(expPoint.gameObject);
            }
        }
    }
}
