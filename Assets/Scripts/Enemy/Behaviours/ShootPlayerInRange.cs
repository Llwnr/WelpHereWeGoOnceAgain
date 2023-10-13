using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootPlayerInRange : MonoBehaviour
{
    private Transform target;
    [SerializeField]private float shootingRange;
    private float dist;

    [SerializeField]private GameObject bullet;
    [SerializeField]private float shootForce, atkInterval;
    private float intervalCount;
    // Start is called before the first frame update
    void Start()
    {
        target = GameObject.FindWithTag("Player").transform;
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
        //Check if player is in range & enemy can shoot
        if(dist <= shootingRange){
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
    }

    void HaltMovement(bool value){
        GetComponent<MoveTowardsPlayer>().SetHaltState(value);
    }

    bool CanEnemyShoot(){
        if(intervalCount <= 0) return true;
        else return false;
    }
}
