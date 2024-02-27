using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TheKiwiCoder;

[System.Serializable]
public class A_CreateHealers : ActionNode
{
    public GameObject healerPrefab;
    public float generationRadius;
    private Transform transform;
    protected override void OnStart() {
        transform = context.transform;
    }

    protected override void OnStop() {
    }

    protected override State OnUpdate() {
        //Create healer and make it heal boss
        Transform healer = GameObject.Instantiate(healerPrefab, GenerateRandomPosAtEdgeOfCircle(), Quaternion.identity).transform;
        healer.GetComponent<HealBoss>().SetBossTarget(transform);
        return State.Success;
    }

    Vector2 GenerateRandomPosAtEdgeOfCircle(){
        //Make sure the point is within boundary
        Vector2 finalPoint;
            Ray2D ray = new Ray2D(transform.position, Random.onUnitSphere);
            finalPoint = ray.GetPoint(generationRadius)*Random.Range(0.8f,1.1f);
        return finalPoint;
    }
}
