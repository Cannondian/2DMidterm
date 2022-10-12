using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class Friend : MonoBehaviour
{
    private SpriteRenderer sr;
    private Rigidbody2D rbd2d;

    public Sprite[] sprites; //0 is alone, 1 is carrying friend
    public GameObject friend;
    public bool hasFriend;
    public TMP_Text textbox;
    public float jumpForce = 35;

    private int index;
    private int nextIndex;

    // Start is called before the first frame update
    void Start()
    {
        sr = GetComponent<SpriteRenderer>();
        rbd2d = GetComponent<Rigidbody2D>();

        hasFriend = false;
        index = SceneManager.GetActiveScene().buildIndex;
        nextIndex = index + 1;
        textbox.text = "";
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKey(KeyCode.Space))
        {
            if (hasFriend) // if carrying friend, put down
            {
                sr.sprite = sprites[0];
                hasFriend = false;
                Instantiate(friend, transform.position + new Vector3(-1.5f,-0.8f,0), Quaternion.identity);
            }
        }

        if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            Debug.Log("Tried to jump");
            if (!hasFriend)
            {
                Debug.Log("Jumped");
                rbd2d.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
            }
        }
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        Debug.Log("Collision detected.");

        if(other.gameObject.CompareTag("Key"))
        {
            Debug.Log("Found my friend.");
            Destroy(other.gameObject);
            sr.sprite = sprites[1];
            hasFriend = true;
        }

        if (other.gameObject.CompareTag("Door") && hasFriend == true)
        {
            Debug.Log("Entered Door");
            SceneManager.LoadScene(nextIndex);
        }

        if (other.gameObject.CompareTag("Door") && hasFriend == false)
        {
            Debug.Log("Door is locked");
        }
    }


    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.name == "signpost6")
        {
            textbox.text = "This way to Underground City Hospital.";
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.name == "signpost6") { textbox.text = "";  }
    }
}
