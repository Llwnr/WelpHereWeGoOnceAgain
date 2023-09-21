using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateObject : MonoBehaviour
{
    [SerializeField]private float speed;

    // Update is called once per frame
    void FixedUpdate()
    {
        transform.eulerAngles += new Vector3(0,0, speed);
    }
}
