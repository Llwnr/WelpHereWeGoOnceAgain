using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ApplyDrag : MonoBehaviour
{
    private Rigidbody2D rb;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        rb.velocity *= 0.9f;
    }
}
