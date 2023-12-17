using FMOD.Studio;
using FMODUnity;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlaySfxOnDestroy : MonoBehaviour
{
    private EventInstance instance;
    public EventReference sfx;

    public bool scaleWithDistance = false;

    private void OnDestroy() {
        instance = RuntimeManager.CreateInstance(sfx);
        instance.start();

        if (scaleWithDistance) {
            float dist = Vector2.Distance(GameObject.FindWithTag("Player").transform.position, transform.position);
            instance.setParameterByName("Distance", dist);
            Debug.Log(dist);
        }
    }
}
