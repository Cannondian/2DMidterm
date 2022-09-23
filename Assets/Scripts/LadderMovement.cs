using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LadderMovement : MonoBehaviour
{
    private float vertical;
    public float speed;
    private bool isLadder = false;
    private bool isClimbing = false;
    

    private Rigidbody2D rb;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        vertical = Input.GetAxis("Vertical");

        if(isLadder && Mathf.Abs(vertical) > 0f){
            isClimbing = true;
            Debug.Log("Climbing now");
        }
        
    }

    private void FixedUpdate(){
        if(isClimbing == true){
            rb.gravityScale = 0f;
            rb.velocity = new Vector2(rb.velocity.x, vertical * speed);
            
        }
        else{
            
            rb.gravityScale = 10f;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision){
        if(collision.CompareTag("Ladder")){
            isLadder = true;
            Debug.Log("Touching Ladder");
        }
    }

    private void OnTriggerExit2D(Collider2D collision){
        if(collision.CompareTag("Ladder")){
            isLadder = false;
            isClimbing = false;
        }
    }
}
