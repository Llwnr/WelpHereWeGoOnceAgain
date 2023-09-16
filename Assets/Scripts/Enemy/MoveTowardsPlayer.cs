using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveTowardsPlayer : MonoBehaviour
{
    private Transform target;
    private Rigidbody2D rb;

    public Vector2 dir;

    [SerializeField]private float moveSpeed, maxMoveSpeed;
    //Don't limit movement speed when external force is applied
    private bool externalForceApplied = false;
    private bool haltMovement = false;
    // Start is called before the first frame update
    void Start()
    {
        target = GameObject.FindWithTag("Player").transform;
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if(haltMovement){
            return;
        }
        //Don't use this script when external force is applied. Get stunned when external force such as knockback is applied
        if(!externalForceApplied){
            dir = (target.position - transform.position).normalized;
            rb.AddForce(dir*moveSpeed, ForceMode2D.Impulse);
        
            rb.velocity = Vector2.ClampMagnitude(rb.velocity, maxMoveSpeed);
        }
        //Implement drag/friction when external force is applied
        else{
            rb.velocity *= 0.75f;
        }
    }

    //For a couple of duration the object has very high max velocity
    public void SetExternalForceToActive(float duration){
        externalForceApplied = true;
        StartCoroutine(ResetExternalForce(duration));
    }

    public void SetHaltState(bool value){
        haltMovement = value;
    }

    IEnumerator ResetExternalForce(float duration){
        yield return new WaitForSeconds(duration);
        externalForceApplied = false;
    }
}
