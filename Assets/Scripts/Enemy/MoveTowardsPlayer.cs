using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveTowardsPlayer : MonoBehaviour
{
    private Transform target;
    private Rigidbody2D rb;

    private Vector2 dir;

    [SerializeField]private float moveSpeed, maxMoveSpeed;
    private float movespeedMultiplier = 1;
    //Don't limit movement speed when external force is applied
    private bool externalForceApplied = false;
    private bool haltMovement = false;

    private IEnumerator moveSpeedCoroutine;//Keep track of movespeed;
    // Start is called before the first frame update
    void Start()
    {
        target = FindPlayer.GetPlayer();
        rb = GetComponent<Rigidbody2D>();
    }

    //To make enemy move faster/slower
    public void SetMovespeedMultiplier(float amt, float duration){
        movespeedMultiplier = amt;//Slowdown enemy movement

        //Reset the duration to stop slowdown when setting slowdown multipliers
        if(moveSpeedCoroutine != null) StopCoroutine(moveSpeedCoroutine);
        moveSpeedCoroutine = ResetMovespeed(duration);
        StartCoroutine(moveSpeedCoroutine);
    }

    void ResetMovespeed(){
        movespeedMultiplier = 1;
    }

    IEnumerator ResetMovespeed(float timer){
        yield return new WaitForSeconds(timer);
        ResetMovespeed();
    }

    // Update is called once per frame
    void FixedUpdate()
    {   if (target == null) return;
        if(haltMovement){
            return;
        }
        if(target == null) return;
        //Don't use this script when external force is applied. Get stunned when external force such as knockback is applied
        if(!externalForceApplied){
            dir = (target.position - transform.position).normalized;
            rb.AddForce(dir*moveSpeed, ForceMode2D.Impulse);
        
            rb.velocity = Vector2.ClampMagnitude(rb.velocity, maxMoveSpeed * movespeedMultiplier);
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

    public bool GetExternalForceStatus() {
        return externalForceApplied;
    }

    public void SetHaltState(bool value){
        haltMovement = value;
    }

    IEnumerator ResetExternalForce(float duration){
        yield return new WaitForSeconds(duration);
        externalForceApplied = false;
    }
}
