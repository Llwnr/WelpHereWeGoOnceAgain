﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowTarget : MonoBehaviour
{
    [SerializeField]private Transform target;
    [SerializeField] private Vector3 offset;

    private void Update() {
        if(target != null)  transform.position = target.position + offset;
    }
}
