using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PerlinNoise : MonoBehaviour
{
    public int width = 256;
    public int height = 256;
    public float frequency;

    public float GetPerlinNoise(float x, float y){
        float xCoord = x/width * frequency;
        float yCoord = y/height * frequency;
        return Mathf.PerlinNoise(xCoord, yCoord)*2-1;
    }
}
