using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.Universal;
using UnityEngine.Rendering;

public class ManageChromaticAberration : MonoBehaviour
{
    private VolumeProfile profile;
    private ChromaticAberration chromaticAberration;
    [SerializeField] private float duration, maxIntensity, minIntensity;
    // Start is called before the first frame update
    void OnEnable() {
        profile = GetComponent<Volume>().profile;
        //Get chromatic aberration component
        if (profile.TryGet(out chromaticAberration)) {
            chromaticAberration.intensity.value = 40;
        }
        else {
            Debug.LogError("Can't find " + GetType().Name);
        }
    }
}
