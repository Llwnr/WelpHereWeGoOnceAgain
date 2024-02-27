using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TheKiwiCoder;

[System.Serializable]
public class A_TelegraphStart : ActionNode
{
    public int numOfTelegraphs;
    public Vector3 telegraphScale;
    public GameObject chargingAnimPrefab;
    public float duration;
    private float durationCounter;
    protected override void OnStart() {
        durationCounter = duration;
        context.transform.GetComponent<TelegraphManager>().CreateTelegraphs(numOfTelegraphs, chargingAnimPrefab, telegraphScale, duration);
    }

    protected override void OnStop() {
        
    }

    protected override State OnUpdate() {
        durationCounter -= Time.deltaTime;
        if(durationCounter > 0) return State.Running;
        
        return State.Success;
    }
}
