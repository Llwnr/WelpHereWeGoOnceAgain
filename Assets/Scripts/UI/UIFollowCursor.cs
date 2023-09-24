using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIFollowCursor : MonoBehaviour
{
    [SerializeField]private Vector3 offset;
    // Update is called once per frame
    void FixedUpdate()
    {
        transform.position = Input.mousePosition + offset;
    }
}
