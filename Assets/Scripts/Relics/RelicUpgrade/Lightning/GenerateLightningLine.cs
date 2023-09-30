using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GenerateLightningLine : MonoBehaviour
{
    private Vector2 currPos;
    private Vector2 finalPos;

    [SerializeField]private LineRenderer lineRenderer;

    public void SetTargetPos(Vector2 finalPos){
        currPos = transform.position;
        this.finalPos = finalPos;

        lineRenderer.positionCount = 2;
        lineRenderer.SetPosition(0, currPos);
        lineRenderer.SetPosition(1, finalPos);

        Debug.Log("Lightning generated");
    }
}
