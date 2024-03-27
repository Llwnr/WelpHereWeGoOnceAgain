using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.Universal;
using UnityEngine.Rendering;

public class AnimateLensDistortion : MonoBehaviour
{
    private VolumeProfile profile;
    private LensDistortion lensDistortion;
    [SerializeField]private float duration, maxIntensity, minIntensity;
    // Start is called before the first frame update
    void OnEnable()
    {
        profile = GetComponent<Volume>().profile;
        //Get lensdistortion component
        if(profile.TryGet(out lensDistortion)) {
            IncreaseLensIntensity();
        }
        else {
            Debug.LogError("Can't find " + GetType().Name);
        }
    }

    private void IncreaseLensIntensity() {
        LeanTween.value(gameObject, SetDistortionIntensity, minIntensity, maxIntensity, duration*0.5f).setOnComplete(DisableLensIntensity);
    }

    void DisableLensIntensity() {
        LeanTween.value(gameObject, SetDistortionIntensity, maxIntensity, minIntensity, duration*0.5f).setOnComplete(DisablePostProcess);
    }

    void DisablePostProcess() {
        foreach (MonoBehaviour scripts in gameObject.GetComponents<MonoBehaviour>()) {
            scripts.enabled = false;
        }
    }

    private void SetDistortionIntensity( float intensity) {
        lensDistortion.intensity.value = intensity;
    }
}
