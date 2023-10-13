using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class ScreenShaker : MonoBehaviour
{
    public static ScreenShaker Instance;

    private CinemachineBasicMultiChannelPerlin camPerlin;
    private void Awake() {
        camPerlin = GetComponent<CinemachineVirtualCamera>().GetCinemachineComponent<CinemachineBasicMultiChannelPerlin>();
        
        if(Instance != null){
            Debug.LogError("ScreenShaker instance already exists");
            return;
        }
        Instance = this;
    }

    //FOR SCREENSHAKE ATTRIBUTES
    private float durationCount, fadeOutDurationCount, fadeOutDuration;
    //Shake screen based on attributes given
    public void ShakeScreenOnce(float intensity, float frequency, float duration, float fadeOutDuration){
        camPerlin.m_AmplitudeGain = intensity;
        camPerlin.m_FrequencyGain = frequency;
        durationCount = duration;
        this.fadeOutDuration = fadeOutDuration;
        fadeOutDurationCount = fadeOutDuration;
    }

    //Stop screen shake
    void StopShake(){
        camPerlin.m_AmplitudeGain = 0;
        camPerlin.m_FrequencyGain = 0;
    }

    void FadeoutShake(){
        camPerlin.m_AmplitudeGain *= fadeOutDurationCount/fadeOutDuration;
        camPerlin.m_FrequencyGain *= fadeOutDurationCount/fadeOutDuration;
    }

    private void FixedUpdate() {
        //Stop screen shake when durations end
        if(durationCount <= 0 && fadeOutDurationCount <= 0){
            StopShake();
            return;
        }
        //Reduce duration as long as screen shake is active
        if(durationCount > 0){
            durationCount -= Time.fixedDeltaTime;
        }
        //When duration ends and there is fade out, slowly decrease intensity of screen shake
        if(durationCount <= 0 && fadeOutDurationCount > 0){
            //Slowly fade out screenshake
            FadeoutShake();
            fadeOutDurationCount -= Time.fixedDeltaTime;
        }
        

    }
}
