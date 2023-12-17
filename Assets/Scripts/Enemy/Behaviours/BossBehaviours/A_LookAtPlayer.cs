using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TheKiwiCoder;

[System.Serializable]
public class A_LookAtPlayer : ActionNode
{
    private Transform player;
    public float rotateSpeed;
    public float duration;
    private float durationCounter;

    protected override void OnStart() {
        player = FindPlayer.GetPlayer();
        ResetDuration();
    }

    protected override void OnStop() {
    }

    protected override State OnUpdate() {
        //Rotate object smoothly
        Vector2 targetDir = (player.position - context.transform.position).normalized;
        float targetAngle = (Mathf.Atan2(targetDir.y, targetDir.x) * Mathf.Rad2Deg - 90f + 360)%360;

        //If difference in rotation is a lot(i.e. from 355 to 365(which is 355 to 5 in angle%360 terms) to still go linearly(355->360 then 0->5)
        //Increase target angle(5 in this case) by 360
        float angleDiff = context.transform.localRotation.eulerAngles.z - targetAngle;
        if(Mathf.Abs(angleDiff) > 240){
            if(targetAngle < context.transform.localRotation.eulerAngles.z){
                targetAngle += 360;
            }else{
                targetAngle -= 360;
            }
        }
        context.transform.eulerAngles = new Vector3(0,0, Mathf.Lerp(context.transform.localRotation.eulerAngles.z, targetAngle, rotateSpeed*Time.deltaTime));
        
        //Basic duration management
        durationCounter -= Time.deltaTime;

        if(durationCounter <= 0){
            return State.Success;
        }

        return State.Running;
    }

    void ResetDuration(){
        durationCounter = duration;
    }
}
