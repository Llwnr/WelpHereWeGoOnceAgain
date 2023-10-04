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
        //Set player as pass through enemies
        gameObject.layer = LayerMask.NameToLayer("PlayerPassThrough");
    }

    public void OnDashEnd(){
        //Reset to default
        gameObject.layer = LayerMask.NameToLayer("Player");
    }
}
