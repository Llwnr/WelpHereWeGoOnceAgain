using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DashManager : MonoBehaviour
{
    //MANAGE OBSERVERS
    private List<IOnDash> dashListeners = new List<IOnDash>();
    public void AddDashListener(IOnDash listener){
        dashListeners.Add(listener);
    }
    public void RemoveDashListener(IOnDash listener){
        dashListeners.Remove(listener);
    }
    //Notify that player has dashed
    void NotifyDashStart(){
        foreach(IOnDash listener in dashListeners){
            listener.OnDashStart();
        }
    }
    //Notify that player stopped dashing
    void NotifyDashEnd(){
        foreach(IOnDash listener in dashListeners){
            listener.OnDashEnd();
        }
    }
    
    private PlayerMovement playerMovement;
    private Rigidbody2D rb;

    [SerializeField]private float dashCooldown;
    private float cooldownCounter;

    private float hDir, vDir = 0;

    [Header ("Dash properties")]
    [SerializeField]private float dashForce;
    [SerializeField]private float maxDashSpeed, dashDuration;
    private float durationCounter;

    private bool isDashing = false;

    private void Start() {
        cooldownCounter = 0;
        ResetDurationCooldown();
        playerMovement = GetComponent<PlayerMovement>();
        rb = GetComponent<Rigidbody2D>();
    }

    //Get the direction player is moving in order to dash in that direction
    void GetDirection(){
        //To keep record of the direction player last moved in case player dashes without any key pressed
        float prevHDir = hDir;
        float prevVDir = vDir;

        hDir = Input.GetAxisRaw("Horizontal");
        vDir = Input.GetAxisRaw("Vertical");

        if(hDir == 0 && vDir == 0){
            //If player provides no direction input then revert direction to the last moving direction
            hDir = prevHDir;
            vDir = prevVDir;
        }
    }

    //This implements a cooldown once dash is used.
    void ResetDashCooldown(){
        cooldownCounter = dashCooldown;
    }

    //This resets the "how long does a dash last"
    void ResetDurationCooldown(){
        durationCounter = dashDuration;
    }

    // Update is called once per frame
    void Update()
    {
        //Record the direction to dash
        GetDirection();

        cooldownCounter -= Time.deltaTime;

        //Start dashing
        if(Input.GetKeyDown(KeyCode.Space) && CanDash()){
            StartDash();
            ResetDashCooldown();
        }

        if(isDashing){
            durationCounter -= Time.deltaTime;
            if(durationCounter <= 0){
                StopDash();
            }
        }
    }

    void StartDash(){
        isDashing = true; //For dash to occur for certain duration
        playerMovement.SetMovementControl(false);        

        rb.AddForce(dashForce*new Vector2(hDir, vDir), ForceMode2D.Impulse);
        rb.velocity = Vector2.ClampMagnitude(rb.velocity, maxDashSpeed);

        NotifyDashStart();
    }

    void StopDash(){
        playerMovement.SetMovementControl(true);
        ResetDurationCooldown();
        isDashing = false;

        NotifyDashEnd();
    }

    public bool GetPlayerDashing(){
        return isDashing;
    }



    //Check if player can dash
    bool CanDash(){
        if(cooldownCounter <= 0) return true;
        return false;
    }
}
