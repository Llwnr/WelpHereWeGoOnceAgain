using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using FMODUnity;

public class PlaySfxOnSkillActivation : MonoBehaviour, IOnAttack
{
    public EventReference sfx;
    public void OnAttack()
    {
        RuntimeManager.PlayOneShot(sfx, transform.position);
    }
}
