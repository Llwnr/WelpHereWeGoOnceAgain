using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelUpAnim : MonoBehaviour, IOnLevelUp
{
    [SerializeField]private ParticleSystem myParticle;

    private float realTimeInSeconds;
    //private bool startSimulation = false;

    private void Awake() {
        PlayerLevelManager.AddLevelupListener(this);
        myParticle.Stop();
    }

    private void OnDestroy() {
        PlayerLevelManager.RemoveLevelupListener(this);
    }

    public void OnLevelUp() {
        myParticle.Play();
    }
}
