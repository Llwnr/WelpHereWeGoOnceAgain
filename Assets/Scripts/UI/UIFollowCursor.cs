using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIFollowCursor : MonoBehaviour
{
    [SerializeField]private Vector3 offset;
    [SerializeField] private bool worldSpace;
    // Update is called once per frame
    void FixedUpdate()
    {
        //Make the object follow the cursor
        if (worldSpace) {
            transform.position = (Vector2)Camera.main.ScreenToWorldPoint(Input.mousePosition) + (Vector2)offset;
            return;
        }
        transform.position = Input.mousePosition + offset;
    }
}
