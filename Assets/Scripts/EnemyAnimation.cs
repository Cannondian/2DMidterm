using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAnimation : MonoBehaviour
{
    public Sprite[] walkAnimation;
    private SpriteRenderer sRenderer;

    private float frameTimer = 0;
    private int frameIndex = 0;

    public float animationFPS;

    void Start()
    {
        sRenderer = GetComponent<SpriteRenderer>();
    }

    void Update()
    {
        frameTimer -= Time.deltaTime;
        if (frameTimer <= 0.0f)
        {
            frameTimer = 1 / animationFPS;
            frameIndex %= walkAnimation.Length;
            sRenderer.sprite = walkAnimation[frameIndex];
        }
    }
}

