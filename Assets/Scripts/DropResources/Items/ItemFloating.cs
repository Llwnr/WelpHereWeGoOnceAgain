using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemFloating : MonoBehaviour
{
    private Vector2 origPos;
    [SerializeField]private float maxHeight, floatSpeed;
    private bool goUp = true;

    private void Start() {
        origPos = transform.position;
    }
    
    private void Update() {
        Vector2 targetPosUp = origPos+new Vector2(0, maxHeight);
        Vector2 targetPosDown = origPos - new Vector2(0, maxHeight);
        if(Input.GetKeyDown(KeyCode.K)){
            goUp = !goUp;
        }
        if(goUp){
            transform.position = Vector2.Lerp(transform.position, (Vector2)transform.position+new Vector2(0,maxHeight*0.7f), floatSpeed*Time.deltaTime);
            //Once you reach a certain distance, change direction
            if(Vector2.Distance(transform.position, targetPosUp) <= 0.05f){
                ChangeDirection();
            }
        }else{
            transform.position = Vector2.Lerp(transform.position, (Vector2)transform.position-new Vector2(0,maxHeight*0.7f), floatSpeed*Time.deltaTime);
            if(Vector2.Distance(transform.position, targetPosDown) <= 0.05f){
                ChangeDirection();
            }
        }
    }

    void ChangeDirection(){
        goUp = !goUp;
    }
}
