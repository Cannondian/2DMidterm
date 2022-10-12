using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    //Starting Variables

    public float speed = 5;
    private float moveInput;
    Rigidbody2D rb2D;
    Animator walkingAnim;
    private SpriteRenderer rend;

    //private CameraShake camShaker;

    //public GameObject cam;
    
    //Starting Conditions
   


    // Start is called before the first frame update
    void Start()
    {
        rb2D = GetComponent<Rigidbody2D>();
        if (GetComponent<Friend>() == null)
        {
            walkingAnim = gameObject.GetComponent<Animator>();
        }
        // walkingAnim = gameObject.GetComponent<Animator>();
        rend = GetComponent<SpriteRenderer>();

    }

    // Update is called once per frame
    void Update()
    {
        if(moveInput > 0 || moveInput < 0){
            Debug.Log("Walking");
            if(GetComponent<Friend>() == null)
            {
                walkingAnim.SetBool("Walking", true);
            }
            // walkingAnim.SetBool("Walking", true);
        }
        else if(moveInput == 0){
            Debug.Log("Not Walking");
            if (GetComponent<Friend>() == null)
            {
                walkingAnim.SetBool("Walking", false);
            }
            // walkingAnim.SetBool("Walking", false);
        }

        if(Input.GetAxisRaw("Horizontal") > 0){
            rend.flipX = false;
        }
        if(Input.GetAxisRaw("Horizontal") < 0){
            rend.flipX = true;
        }
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
