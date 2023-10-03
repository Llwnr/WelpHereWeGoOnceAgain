using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField]private float moveSpeed, maxMoveSpeed;
    private PlayerBasicStats playerStats;
    private Rigidbody2D rb;

    private float hDir, vDir;

    private bool normalMovementActive = true;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        playerStats = PlayerBasicStats.instance;
    }

    public void SetMovementControl(bool value){
        normalMovementActive = value; 
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if(normalMovementActive == false) return;

        hDir = Input.GetAxisRaw("Horizontal");
        vDir = Input.GetAxisRaw("Vertical");

        if(hDir == 0 && vDir == 0){
            //Gradually slow down player
            rb.velocity *= 0.75f;
        }

        rb.AddForce(new Vector2(hDir, vDir) * moveSpeed * playerStats.GetMovementSpeed(), ForceMode2D.Impulse);
        rb.velocity = Vector2.ClampMagnitude(rb.velocity, maxMoveSpeed*playerStats.GetMovementSpeed());
    }
}
