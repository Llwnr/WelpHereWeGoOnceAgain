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

    protected override void OnStart() {
        ThrowProjectile(projectilePrefab);
    }

    protected override void OnStop() {
    }

    protected override State OnUpdate() {
        return State.Success;
    }

    void ThrowProjectile(GameObject prefab){
        for(int i=0; i<numOfAngles; i++){
            GameObject newProj = GameObject.Instantiate(prefab, context.transform.position, Quaternion.identity);
            Rigidbody2D rb = newProj.GetComponent<Rigidbody2D>();
            //Convert angle to direction
            float angle = context.transform.eulerAngles.z+90 + i*(360f/numOfAngles);
            Vector2 dir;
            dir.x = Mathf.Cos(angle*Mathf.Deg2Rad);
            dir.y = Mathf.Sin(angle*Mathf.Deg2Rad);

            rb.AddForce(dir*throwForce, ForceMode2D.Impulse);
            rb.velocity = Vector2.ClampMagnitude(rb.velocity, maxSpeed);
        }
    }
}
