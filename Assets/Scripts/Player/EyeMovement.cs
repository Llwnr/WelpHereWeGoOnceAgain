using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EyeMovement : MonoBehaviour
{
    public float radiusX, radiusY = 1;
    [SerializeField]private Transform objectToBind;
    private Vector2 origPos;
    private Vector2 offsets;
    [SerializeField]private float offsetMul;

    private void Start() {
        origPos = objectToBind.localPosition;
        offsets = Vector2.zero;
    }

    // Update is called once per frame
    void Update()
    {
        //Make the object look and follow mouse pos but within a barrier
        Vector2 dir = (Vector2)Camera.main.ScreenToWorldPoint(Input.mousePosition) - (Vector2)objectToBind.position;
        float angle = Mathf.Atan2(dir.y, dir.x)*Mathf.Rad2Deg;
        offsets = dir*offsetMul;
        //Find boundary point in elipse
        Vector2 maxBounds = GetBoundaryPoint(angle);
        offsets.x = Mathf.Clamp(offsets.x, -Mathf.Abs(maxBounds.x), Mathf.Abs(maxBounds.x));
        offsets.y = Mathf.Clamp(offsets.y, -Mathf.Abs(maxBounds.y), Mathf.Abs(maxBounds.y));
        objectToBind.localPosition = origPos+offsets;
    }

    Vector2 GetBoundaryPoint(float angle){
        float radians = angle * Mathf.Deg2Rad;
        float x = radiusX * Mathf.Cos(radians);
        float y = radiusY * Mathf.Sin(radians);
        return new Vector2(x, y);
    }
}
