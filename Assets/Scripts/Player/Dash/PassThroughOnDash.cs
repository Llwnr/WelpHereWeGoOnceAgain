using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PassThroughOnDash : MonoBehaviour, IOnDash
{
    private DashManager dashManager;
    private Collider2D myCollider;

    private void Start() {
        myCollider = GetComponent<Collider2D>();
        dashManager = GameObject.FindWithTag("Player").GetComponent<DashManager>();
        dashManager.AddDashListener(this);
    }

    private void OnDisable() {
        dashManager.RemoveDashListener(this);
    }

    public void OnDashStart(){
        //Disable myCollider
        myCollider.enabled = false;
    }

    public void OnDashEnd(){
        //Enable myCollider
        myCollider.enabled = true;
    }
}
