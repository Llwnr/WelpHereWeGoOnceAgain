using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowTarget : MonoBehaviour
{
    [SerializeField]private Transform target;
    [SerializeField] private Vector3 offset;

    private void OnEnable() {
        SetPosition();
    }

    private void Update() {
        SetPosition();
    }

    void SetPosition(){
        if(target != null)  transform.position = target.position + offset;
    }
}
