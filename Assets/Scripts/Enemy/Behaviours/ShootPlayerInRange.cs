using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using FMODUnity;

[RequireComponent(typeof(MoveTowardsPlayer))]
public class ShootPlayerInRange : MonoBehaviour
{
    private Transform target;
    [SerializeField]private float shootingRange;
    private float dist;

    [SerializeField]private GameObject bullet;
    [SerializeField]private float shootForce, atkInterval;
    private float intervalCount;

    public EventReference sfx;
    // Start is called before the first frame update
    void Start()
    {
        target = FindPlayer.GetPlayer();
        intervalCount = atkInterval;
    }

    private void Update() {
        intervalCount -= Time.deltaTime;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if(target == null) return;
        
        dist = Vector2.Distance(target.position, transform.position);
        //Stop and shoot if player is in range. But enable movement when external force like knockback is applied
        if(dist <= shootingRange && !GetComponent<MoveTowardsPlayer>().GetExternalForceStatus()){
            HaltMovement(true);//Stop moving and shoot
            GetComponent<Rigidbody2D>().velocity *= 0;
            if(CanEnemyShoot()){
                ShootBullet((target.position-transform.position).normalized);
            }
        }else{
            HaltMovement(false);//When out of range... start following player again
        }
    }

    void ShootBullet(Vector2 dir){
        Rigidbody2D bulletRb = Instantiate(bullet, transform.position, Quaternion.identity).GetComponent<Rigidbody2D>();
        bulletRb.AddForce(shootForce*dir, ForceMode2D.Impulse);

        //Reset atk interval
        intervalCount = atkInterval;

        RuntimeManager.PlayOneShot(sfx, transform.position);
    }

    void HaltMovement(bool value){
        GetComponent<MoveTowardsPlayer>().SetHaltState(value);
    }

    bool CanEnemyShoot(){
        if(intervalCount <= 0) return true;
        else return false;
    }

    private void OnDrawGizmosSelected() {
        Gizmos.DrawWireSphere(transform.position, shootingRange);
    }
}
