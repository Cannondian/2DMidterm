using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    //Starting Variables

    public float speed = 5;
    private float moveInput;
    Rigidbody2D rb2D;

    //private CameraShake camShaker;

    //public GameObject cam;
    
    //Starting Conditions
   


    // Start is called before the first frame update
    void Start()
    {
        rb2D = GetComponent<Rigidbody2D>();
        

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void FixedUpdate(){
        moveInput = Input.GetAxisRaw("Horizontal");
        rb2D.velocity = new Vector2(moveInput * speed, rb2D.velocity.y);
    }

    public void OnCollisionEnter2D(Collision2D collide)
    {
        //if (collide.gameObject.tag == "ShakeTest")
        //{
            //Debug.Log("Collides");
            //camShaker = cam.GetComponent<CameraShake>();
            //CameraShake shaking = camShaker;
            //shaking.TriggerShake();
        //}
    }

}
