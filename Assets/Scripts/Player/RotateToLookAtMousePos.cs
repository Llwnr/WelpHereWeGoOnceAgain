using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateToLookAtMousePos : MonoBehaviour
{
    // Update is called once per frame
    void Update()
    {
        LookAtMouse();
    }

    void LookAtMouse(){
        //Offset mouse position by 0.33f since you want to look at center of the mouse not tip of the mouse
        Vector2 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition) + new Vector3(0.33f, -0.33f, 0);
        float zAngle = ConvertPosToAngle(mousePos);
        //Change rotation of player
        transform.eulerAngles = new Vector3(0, 0, zAngle);

        //Converts the position into angle so that player can look to the position at that angle
        float ConvertPosToAngle(Vector2 pos){
            Vector2 posDiff = pos - (Vector2)transform.position;
            float angle = Mathf.Atan2(posDiff.y, posDiff.x) * Mathf.Rad2Deg - 90f;
            return angle;
        }
    }
}
