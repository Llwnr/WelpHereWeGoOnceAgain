using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIFollowCursor : MonoBehaviour
{
    [SerializeField]private Vector3 offset;
    [SerializeField] private bool worldSpace;

    float resolutionRelative;
    
    private void Start() {
        float resolutionRelative = Screen.width/1920f;
    }
    // Update is called once per frame
    void Update()
    {
        //Make the object follow the cursor
        if (worldSpace) {
            
            transform.position = (Vector2)Camera.main.ScreenToWorldPoint(Input.mousePosition) + (Vector2)offset*resolutionRelative;
            return;
        }
        transform.position = Input.mousePosition + offset*80f * resolutionRelative;
    }
}
