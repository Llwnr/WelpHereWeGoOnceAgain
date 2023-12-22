using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseCursor : MonoBehaviour
{
    [SerializeField]private Texture2D cursorTexture;
    [SerializeField]private bool disableSystemCursor; 
    // Start is called before the first frame update
    void Start()
    {
        Debug.Log("Setting up application framerate");
        Application.targetFrameRate = 60;
        Debug.Log("Setting up cursor");
        if(disableSystemCursor){
            Cursor.visible = false;
            return;
        }
        Cursor.SetCursor(cursorTexture, Vector2.zero, CursorMode.Auto);
        
    }
}
