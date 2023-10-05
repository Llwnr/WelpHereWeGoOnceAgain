using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkillConnectionLine : MonoBehaviour
{
    public void SetConnection(Transform target, Transform origin){
        //Set line to be middle of target and self
        transform.position = (target.position+origin.position)*0.5f;
        transform.localScale = new Vector3(1, 3,1);

        //Rotate line to connect both skills
        Vector2 dir = target.position - origin.position;
        float angle = Mathf.Atan2(dir.y, dir.x)*Mathf.Rad2Deg-90;
        transform.eulerAngles = new Vector3(0,0, angle);
    }
}
