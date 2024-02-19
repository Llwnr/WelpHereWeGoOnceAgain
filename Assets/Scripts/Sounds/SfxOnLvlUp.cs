using UnityEngine;
using FMOD.Studio;
using FMODUnity;

public class SfxOnLvlUp : MonoBehaviour, IOnLevelUp
{
    public EventReference lvlupSfx;
    // Start is called before the first frame update
    void Start()
    {
        PlayerLevelManager.AddLevelupListener(this);
    }

    private void OnDestroy() {
        PlayerLevelManager.RemoveLevelupListener(this);
    }

    public void OnLevelUp()
    {
        RuntimeManager.PlayOneShot(lvlupSfx);
    }
}
