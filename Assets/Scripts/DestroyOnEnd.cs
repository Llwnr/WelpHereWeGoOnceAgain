using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyOnEnd : MonoBehaviour
{
    public void DestroySelf(){
        Destroy(gameObject);
    }
}
