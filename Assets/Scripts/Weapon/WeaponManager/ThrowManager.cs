using System.Collections;
using System.Collections.Generic;
using Unity.Burst.Intrinsics;
using UnityEngine;

public class ThrowManager : MonoBehaviour
{
    private Vector2 destinationPos, startingPos, shadowLocalOffset, shadowOrigLocalScale;
    [SerializeField]private Transform shadow;
    [SerializeField]private float throwHeight, shadowIncrease;

    //For bezier curve
    private Vector2 pointA, pointB, resultPoint;
    [SerializeField]private float smoothness = 1;
    private int lerpIndex;
    // Start is called before the first frame update
    void Start()
    {
        startingPos = transform.position;
        shadowLocalOffset = shadow.localPosition;
        shadowOrigLocalScale = shadow.localScale;
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
        //Make shadow be behind player
        shadow.localPosition += new Vector3(0,0,1);
        lerpIndex++;
        //Make shadow size bigger/smaller based on height of bomb
        if (lerpIndex / smoothness < 0.5f) {
            shadow.localScale += (Vector3)shadowOrigLocalScale * shadowIncrease * (transform.position.y-shadow.position.y) * 0.1f;
        }
        else {
            shadow.localScale -= (Vector3)shadowOrigLocalScale * shadowIncrease * (transform.position.y - shadow.position.y) * 0.1f;
        }
    }

    Vector2 GetBezierCurvedPoint(int lerpIndex){
        float lerpValue = lerpIndex/smoothness;
        Vector2 heightA, heightB;
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
        Vector2 calculatedPos;
        calculatedPos = Vector2.Lerp(aToMid, midToB, lerpValue);
        return calculatedPos;
    }
}
