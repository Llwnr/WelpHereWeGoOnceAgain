using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShowTutAtStart : MonoBehaviour
{
    [SerializeField]private GameObject tutorial;
    [SerializeField]private float duration;

    // Update is called once per frame
    void Update()
    {
        duration -= Time.deltaTime;
        if(duration <= 0){
            tutorial.SetActive(false);
        }
    }
}
