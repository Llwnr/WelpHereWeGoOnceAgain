using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveToTarget : MonoBehaviour
{
    private Transform target;
    private Rigidbody2D rb;
    [SerializeField]private float speed, maxSpeed;

    private void Awake() {
        rb = GetComponent<Rigidbody2D>();
    }

    public void SetTarget(Transform target){
        this.target = target;
    }

    private void FixedUpdate() {
        rb.AddForce(speed * (target.position - transform.position).normalized, ForceMode2D.Impulse);
        rb.velocity = Vector2.ClampMagnitude(rb.velocity, maxSpeed);
    }
}
