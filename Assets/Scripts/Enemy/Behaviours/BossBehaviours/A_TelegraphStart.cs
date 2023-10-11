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
    protected override void OnStart() {
        context.transform.GetComponent<TelegraphManager>().CreateTelegraphs(numOfTelegraphs, chargingAnimPrefab, telegraphScale);
    }

    protected override void OnStop() {
        
    }

    protected override State OnUpdate() {
        return State.Success;
    }
}
