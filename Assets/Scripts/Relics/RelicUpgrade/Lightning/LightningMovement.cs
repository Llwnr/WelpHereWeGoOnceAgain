using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightningMovement : MonoBehaviour
{
    [SerializeField]private Vector2 dir;
    [SerializeField]float directionalForce, noiseStrength;
    private Vector2 prevDir = Vector2.zero;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        GetComponent<Rigidbody2D>().velocity *= 0.8f;
        float angle = ConvertDirToAngle(prevDir, transform.position);
        GetComponent<Rigidbody2D>().AddForce(dir.normalized*directionalForce, ForceMode2D.Impulse);
        GetComponent<Rigidbody2D>().velocity = Vector2.ClampMagnitude(GetComponent<Rigidbody2D>().velocity, 25);

        //Add variability to Angle 90 deg to right or left so lightning has more varied direction
        GetComponent<Rigidbody2D>().AddForce(ConvertAngleToDir(angle-90)*GetComponent<PerlinNoise>().GetPerlinNoise(transform.position.x, transform.position.y)*noiseStrength, ForceMode2D.Impulse);
        
        prevDir = transform.position;
    }

    float ConvertDirToAngle(Vector2 prevDir, Vector2 currDir){
        Vector2 myDir = currDir-prevDir;
        float angle = Mathf.Atan2(myDir.y, myDir.x) * Mathf.Rad2Deg;
        return angle;
    }

    Vector2 ConvertAngleToDir(float angle){
        Vector2 myDir;
        myDir.x = Mathf.Cos(angle*Mathf.Deg2Rad);
        myDir.y = Mathf.Sin(angle*Mathf.Deg2Rad);
        return myDir;
    }
}
