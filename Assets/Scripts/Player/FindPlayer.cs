using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class FindPlayer
{
    public static Transform GetPlayer() {
        if (GameObject.FindWithTag("Player")) return GameObject.FindWithTag("Player").transform;
        return null;
    }
}
