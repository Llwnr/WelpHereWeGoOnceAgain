using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TheKiwiCoder;

[System.Serializable]
public class A_TelegraphStop : ActionNode
{
    protected override void OnStart() {
        context.transform.GetComponent<TelegraphManager>().StopTelegraph();
    }

    protected override void OnStop() {
        
    }

    protected override State OnUpdate() {
        return State.Success;
    }
}
