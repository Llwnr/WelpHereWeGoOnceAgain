using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayBulletExplodeAnim : MonoBehaviour
{
    [SerializeField]private GameObject explodeAnim;

    private void OnTriggerEnter2D(Collider2D other) {
        if(other.transform.CompareTag("Enemy") || other.transform.CompareTag("Player")){
            Instantiate(explodeAnim, transform.position-new Vector3(0,0,5), Quaternion.identity);
        }
    }
}
