using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyOnTimer : MonoBehaviour
{
    public float timer;

    // Update is called once per frame
    void Update()
    {
        timer -= Time.deltaTime;
        if(timer <= 0) Destroy(gameObject);
    }
}
