using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TheKiwiCoder;

[System.Serializable]
public class A_ChargeDash : ActionNode
{
    public float dashForce, maxSpeed;
    public float duration;
    private float durationCounter;
    private Rigidbody2D rb;
    private Vector2 dashDir;
    protected override void OnStart() {
        rb = context.transform.GetComponent<Rigidbody2D>();
        //Stop transform's other movement from being active while dashing
        rb.GetComponent<MoveTowardsPlayer>().SetHaltState(true);

        dashDir = ConvertAngleToDir(rb.transform.eulerAngles.z+90);

        ResetDuration();
    }

    protected override void OnStop() {
        rb.GetComponent<MoveTowardsPlayer>().SetHaltState(false);
    }

    protected override State OnUpdate() {
        //Move transform
        rb.AddForce(dashDir*dashForce, ForceMode2D.Impulse);
        rb.velocity = Vector2.ClampMagnitude(rb.velocity, maxSpeed);

        //Duration manager
        durationCounter -= Time.deltaTime;
        if(durationCounter <= 0) return State.Success;
        else return State.Running;
    }

    Vector2 ConvertAngleToDir(float angle){
        Vector2 dir;
        dir.x = Mathf.Cos(angle*Mathf.Deg2Rad);
        dir.y = Mathf.Sin(angle*Mathf.Deg2Rad);
        return dir;
    }

    void ResetDuration(){
        durationCounter = duration;
    }
}
