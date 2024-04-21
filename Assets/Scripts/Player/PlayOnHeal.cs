using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayOnHeal : MonoBehaviour
{
    [SerializeField]private ParticleSystem healEffect;
    
    public void PlayEffect(){
        healEffect.Play();
    }
}
