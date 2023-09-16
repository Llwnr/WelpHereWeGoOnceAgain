using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PointsPos : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Debug.Log(GetComponent<SpriteRenderer>().sprite.bounds.size.x);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
