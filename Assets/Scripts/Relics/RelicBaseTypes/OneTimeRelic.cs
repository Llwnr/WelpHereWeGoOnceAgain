using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class OneTimeRelic : Relic
{
    private bool hasActivated = false;

    private void OnEnable() {
        if(hasActivated) return;

        ActivateSkill();
    }
}
