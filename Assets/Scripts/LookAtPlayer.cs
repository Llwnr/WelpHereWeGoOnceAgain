using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LookAtPlayer : MonoBehaviour
{
    private Transform player;
    private Vector2 dir;
    // Start is called before the first frame update
    void Start()
    {
        player = FindPlayer.GetPlayer();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if(player == null) return;
        dir = (player.transform.position - transform.position).normalized;

        //Convert vector to angle
        float angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg - 90;
        transform.eulerAngles = new Vector3(0,0, angle);
    }
}
