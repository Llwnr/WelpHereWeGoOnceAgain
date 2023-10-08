using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TheKiwiCoder;

[System.Serializable]
public class A_TelegraphStart : ActionNode
{
    public int numOfTelegraphs;
    public GameObject chargingAnimPrefab;
    protected override void OnStart() {
        context.transform.GetComponent<TelegraphManager>().CreateTelegraphs(numOfTelegraphs, chargingAnimPrefab);
    }

    protected override void OnStop() {
        
    }

    protected override State OnUpdate() {
        return State.Success;
    }
}
