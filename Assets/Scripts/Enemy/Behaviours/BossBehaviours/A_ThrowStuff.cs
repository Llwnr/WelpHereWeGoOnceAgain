using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TheKiwiCoder;

[System.Serializable]
public class A_ThrowStuff : ActionNode
{
    public GameObject projectilePrefab;
    public float throwForce;
    public float maxSpeed;
    public int numOfAngles;
    [Header ("Instances")]
    public int numOfInstances;
    private int instanceCounter;
    public float rotationOffset;
    //After how many seconds to throw new instance of projectile with offset in rotation
    public float delay;
    private float delayCounter;

    protected override void OnStart() {
        ResetDelay();
        instanceCounter = numOfInstances;
    }

    protected override void OnStop() {
    }

    protected override State OnUpdate() {
        delayCounter -= Time.deltaTime;
        if(delayCounter <= 0){
            ResetDelay();
            //Throw projectiles after each delay
            if(instanceCounter > 0){
                ThrowProjectile(projectilePrefab, rotationOffset*instanceCounter);
                instanceCounter--;
            }
        }
        
        if(instanceCounter <= 0) return State.Success;
        return State.Running;
    }

    void ThrowProjectile(GameObject prefab, float angleOffset){
        for(int i=0; i<numOfAngles; i++){
            GameObject newProj = GameObject.Instantiate(prefab, context.transform.position, Quaternion.identity);
            Rigidbody2D rb = newProj.GetComponent<Rigidbody2D>();
            //Convert angle to direction
            float angle = context.transform.eulerAngles.z+90+angleOffset + i*(360f/numOfAngles);
            Vector2 dir;
            dir.x = Mathf.Cos(angle*Mathf.Deg2Rad);
            dir.y = Mathf.Sin(angle*Mathf.Deg2Rad);

            rb.AddForce(dir*throwForce, ForceMode2D.Impulse);
            rb.velocity = Vector2.ClampMagnitude(rb.velocity, maxSpeed);
        }
    }

    void ResetDelay(){
        delayCounter = delay;
    }
}
