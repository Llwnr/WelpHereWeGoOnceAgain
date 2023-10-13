using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIFollowTarget : MonoBehaviour
{
    [SerializeField]private Transform target;
    [SerializeField]private Vector3 offset;

    // Update is called once per frame
    void FixedUpdate()
    {
        if(target == null) return;
        transform.position = Camera.main.WorldToScreenPoint(target.position+offset);
    }
}
