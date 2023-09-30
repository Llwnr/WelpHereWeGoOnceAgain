using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimateSpriteMask : MonoBehaviour
{
    private SpriteRenderer spriteRenderer;
    private SpriteMask spriteMask;
    // Start is called before the first frame update
    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        spriteMask = GetComponent<SpriteMask>();
    }

    // Update is called once per frame
    void Update()
    {
        spriteMask.sprite = spriteRenderer.sprite;
    }
}
