using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemFloating : MonoBehaviour
{
   // public AudioClip keySound;

    public float amplitude = 0.5f;
    public float frequency = 1f;

    Vector3 posOffset = new Vector3();
    Vector3 tempPos = new Vector3();
    Vector3 startPos = new Vector3();
    private bool playerHas = false;

    public DoorAndKey dk;

    // Start is called before the first frame update
    void Start()
    {
       
        posOffset = transform.position;
        startPos = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        if(dk.hasKey == false)
        {
           // AudioSource.PlayClipAtPoint(keySound, transform.position);
            tempPos = posOffset;
            tempPos.y += Mathf.Sin(Time.fixedTime * Mathf.PI * frequency) * amplitude;

            transform.position = tempPos;
            
        }
        
        
    }

    
}
