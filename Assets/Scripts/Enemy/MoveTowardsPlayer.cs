using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveTowardsPlayer : MonoBehaviour
{
    private Transform target;
    private Rigidbody2D rb;

    public Vector2 dir;

    [SerializeField]private float moveSpeed, maxMoveSpeed;
    // Start is called before the first frame update
    void Start()
    {
        target = GameObject.FindWithTag("Player").transform;
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        dir = (target.position - transform.position).normalized;
        
        rb.AddForce(dir*moveSpeed, ForceMode2D.Impulse);
        rb.velocity = Vector2.ClampMagnitude(rb.velocity, maxMoveSpeed);
    }
}
