using System.Collections;
using System.Collections.Generic;
using Unity.Burst.Intrinsics;
using UnityEngine;

public class ThrowManager : MonoBehaviour
{
    private Vector2 destinationPos, startingPos, shadowLocalOffset;
    [SerializeField]private Transform shadow;
    [SerializeField]private float throwHeight;

    //For bezier curve
    private Vector2 pointA, midAB, pointB, resultPoint;
    [SerializeField]private float smoothness = 1;
    private int lerpIndex;
    // Start is called before the first frame update
    void Start()
    {
        startingPos = transform.position;
        shadowLocalOffset = shadow.localPosition;
        lerpIndex = 0;
    }

    public void SetDestination(Vector2 destinationPos){
        this.destinationPos = destinationPos;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        //Stop once you reach the destination
        if(lerpIndex > smoothness) return;
        //Get bezier curve point based on lerp index
        resultPoint = GetBezierCurvedPoint(lerpIndex);
        transform.position = resultPoint;
        //Set shadow position but without height
        shadow.position = Vector2.Lerp(startingPos, destinationPos, lerpIndex/smoothness) + shadowLocalOffset;
        lerpIndex++;
    }

    Vector2 GetBezierCurvedPoint(int lerpIndex){
        float lerpValue = lerpIndex/smoothness;
        Vector2 heightA, heightB;

        Vector2 calculatedPos = Vector2.zero;
        //Make 4 points... mid point having height
        // pointA = startingPos;
        // pointB = destinationPos;
        // midAB = (pointA+pointB)/2 + new Vector2(0, throwHeight);

        // Vector2 aToMid = Vector2.Lerp(pointA, midAB, lerpValue);
        // Vector2 midToB = Vector2.Lerp(midAB, pointB, lerpValue);
        pointA = startingPos;
        heightA = pointA + new Vector2(0, throwHeight);
        heightB = pointB + new Vector2(0, throwHeight);
        pointB = destinationPos;

        Vector2 aToHeightA, heightAtoHeightB, heightBtoB;
        aToHeightA = Vector2.Lerp(pointA, heightA, lerpValue);
        heightAtoHeightB = Vector2.Lerp(heightA, heightB, lerpValue);
        heightBtoB = Vector2.Lerp(heightB, pointB, lerpValue);

        Vector2 aToMid, midToB;
        aToMid = Vector2.Lerp(aToHeightA, heightAtoHeightB, lerpValue);
        midToB = Vector2.Lerp(heightAtoHeightB, heightBtoB, lerpValue);

        //Create bezier curve for smooth curve
        calculatedPos = Vector2.Lerp(aToMid, midToB, lerpValue);
        return calculatedPos;
    }
}
