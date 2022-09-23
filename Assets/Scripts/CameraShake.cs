using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraShake : MonoBehaviour
{
    private Transform transform;

    private float duration = 0f;

    public float magnitude = 0.7f;

    public float dampingSpeed = 1.0f;

    Vector3 initialPosition;
    // Start is called before the first frame update
    void Awake()
    {
        if(transform == null){
            transform = GetComponent(typeof(Transform)) as Transform;
        }
    }

    void OnEnable(){
        initialPosition = transform.localPosition;

    }

    // Update is called once per frame
    void Update()
    {
        if(duration > 0)
        {
            transform.localPosition = initialPosition + Random.insideUnitSphere * magnitude;

            duration -= Time.deltaTime * dampingSpeed;
        }
        else
        {
            duration = 0f;
            transform.localPosition = initialPosition;
        }
    }

    public void TriggerShake()
    {
        Debug.Log("Shaking");
        duration = 2.0f;
    }
}

