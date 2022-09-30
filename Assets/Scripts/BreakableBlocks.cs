using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BreakableBlocks : MonoBehaviour
{

    public float breakingSpeed = 0.02f;

    private void OnCollisionEnter2D(Collision2D other)
    {
        PlayerController player = other.gameObject.GetComponent<PlayerController>();
        if(player != null)
        {
            Vector3 vel = other.relativeVelocity;
            Debug.Log(vel);
            if(Mathf.Abs(vel.y) > breakingSpeed)
            {
                Destroy(gameObject);
            }
        }
    }
}
