using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bouncing : MonoBehaviour
{
    public float jumpForce = 5;

    public GameObject player;
    Vector3 direction;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        direction = transform.TransformDirection(Vector3.up*jumpForce);
    }

    void OnCollisionEnter2D(Collision2D col)
    {
        if(col.gameObject.CompareTag("Player"))
        {
            player = col.gameObject;
            player.GetComponent<Rigidbody2D>().AddForce(direction, ForceMode2D.Impulse);
        }
    }
}
