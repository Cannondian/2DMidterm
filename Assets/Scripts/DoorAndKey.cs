using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DoorAndKey : MonoBehaviour
{
    public AudioClip keySound;
    public bool hasKey = false;
    private GameObject key;

    private int nextIndex;
    private int index;

    public float itemOffset = 1f;

    


    // Start is called before the first frame update
    void Start()
    {
        index = SceneManager.GetActiveScene().buildIndex;
        nextIndex = index + 1;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        

        if (col.gameObject.CompareTag("Key"))
        {
            hasKey = true;
            Debug.Log("Picked up key");
            key = col.gameObject;
            key.transform.SetParent(transform);
            key.transform.localPosition = new Vector3(itemOffset, 0, 0);
            // Destroy(col.gameObject);

            AudioSource.PlayClipAtPoint(keySound, transform.position);

        }

        // if(col.gameObject.CompareTag("Door") && hasKey == true)
        
    }

    void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.CompareTag("Door") && key != null)
        {
            Debug.Log("Entered Door");
            SceneManager.LoadScene(nextIndex);
        }

        // if(col.gameObject.CompareTag("Door") && hasKey == false)
        if (col.gameObject.CompareTag("Door") && key == null)
        {
            Debug.Log("Door is locked");
        }
    }

}
