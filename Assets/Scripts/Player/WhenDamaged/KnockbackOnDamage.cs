using System.Collections;
using System.Collections.Generic;
using Unity.Burst.Intrinsics;
using UnityEngine;

public class KnockbackOnDamage : MonoBehaviour, IWhenDamaged
{
    [SerializeField]private float radius, knockbackForce, knockbackDuration, slowedTime;
    private HealthManager playerHealthManager;
    // Start is called before the first frame update
    void Start()
    {
        playerHealthManager = GameObject.FindWithTag("Player").GetComponent<HealthManager>();
        playerHealthManager.AddOnDamageListener(this);
    }

    public void WhenDamaged(float dmgAmt, Vector2 hitPoint){
        Vector2 pushDir = Vector2.zero;
        //Get all the objects in radius and push them away
        Collider2D[] colliders = Physics2D.OverlapCircleAll(transform.position, radius);
        Time.timeScale = slowedTime;
        StartCoroutine(ResetTimeScale());

        foreach(Collider2D collider in colliders){
            pushDir = collider.transform.position - transform.position;
            if(collider.transform.CompareTag("Enemy")){
                collider.GetComponent<MoveTowardsPlayer>().SetExternalForceToActive(knockbackDuration);
                collider.attachedRigidbody.AddForce(pushDir.normalized*knockbackForce/Mathf.Min(10f, pushDir.magnitude), ForceMode2D.Impulse);
            }
        }
    }

    IEnumerator ResetTimeScale() {
        yield return new WaitForSecondsRealtime(knockbackDuration*0.75f);
        //Only reset timescale when other menus such as relic selection menu that would pause the game is inactive
        if (Time.timeScale > 0) Time.timeScale = 1;
    }
}
