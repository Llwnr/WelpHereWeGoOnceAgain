using System.Collections;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using Unity.Burst.Intrinsics;
using UnityEngine;

public class DashNearPlayer : MonoBehaviour
{
    [Header ("Dash Settings")]

    [SerializeField]private float radius;
    [SerializeField]private float waitDuration, dashForce, maxDashSpeed, durationForDashable;

    private Vector2 dashDir;
    [SerializeField]private float dashDuration;

    [Header ("Anticipation")]
    [SerializeField]private Transform pivot;
    [SerializeField]private GameObject anticipationObj;

    private bool isCharging = false;
    private Rigidbody2D rb;

    private void Start() {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        //Don't search for colliders when charging dash
        if(isCharging) return;
        //When player is in range dash
        Collider2D[] colliders = Physics2D.OverlapCircleAll(transform.position, radius);
        foreach(Collider2D collider in colliders){
            if(collider.CompareTag("Player")){
                GetComponent<Rigidbody2D>().velocity = Vector2.zero;
                StartCoroutine(ChargeDash(collider.transform));
                isCharging = true;
            }
        }
    }

    IEnumerator ChargeDash(Transform player){
        //For anticipation
        GameObject newAnticipationInfo = Instantiate(anticipationObj, transform.position, Quaternion.identity);
        newAnticipationInfo.transform.SetParent(pivot, false);

        float waitDurationCounter = waitDuration;
        while(waitDurationCounter > waitDuration*0.1f){
            //Look at player as if fixing target
            dashDir = (player.position - transform.position).normalized;
            float angle = Mathf.Atan2(dashDir.y, dashDir.x) * Mathf.Rad2Deg + 90;
            pivot.transform.eulerAngles = new Vector3(0,0, angle);
            waitDurationCounter -= Time.deltaTime;

            yield return null;
        }
        while(waitDurationCounter > 0){
            //Destroy anticipation as now the enemy will not change its anticipated location
            Destroy(newAnticipationInfo);

            //Do nothing so player can react
            waitDurationCounter -= Time.deltaTime;
            yield return null;  
        }
        
        //Dash
        Dash();
    }

    void Dash(){
        //Stop object from using default moving speed limiter
        GetComponent<MoveTowardsPlayer>().SetHaltState(true);
        rb.AddForce(dashDir*dashForce, ForceMode2D.Impulse);
        rb.velocity = Vector2.ClampMagnitude(rb.velocity, maxDashSpeed);

        //Also make object go through its enemies while dashing
        transform.GetComponent<Collider2D>().enabled = false;
        transform.GetChild(0).GetComponent<Collider2D>().enabled = false;

        StartCoroutine(StopDash());
    }

    IEnumerator StopDash(){
        //Make enemy follor player again instead of dashing
        yield return new WaitForSeconds(dashDuration);
        //Make object move at normal speed limit
        GetComponent<MoveTowardsPlayer>().SetHaltState(false);
        //Enable colliders again
        transform.GetComponent<Collider2D>().enabled = true;
        transform.GetChild(0).GetComponent<Collider2D>().enabled = true;
        StartCoroutine(MakeObjectDashable());
    }

    IEnumerator MakeObjectDashable(){
        yield return new WaitForSeconds(durationForDashable);
        isCharging = false;
    }
}
