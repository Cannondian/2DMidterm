using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DoorAndKey : MonoBehaviour
{
    
    private bool hasKey = false;

    private int nextIndex;
    private int index;


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
        if(col.gameObject.CompareTag("Key"))
        {
            hasKey = true;
            Debug.Log("Picked up key");
            Destroy(col.gameObject);
        }

        if(col.gameObject.CompareTag("Door") && hasKey == true)
        {
            Debug.Log("Entered Door");
            SceneManager.LoadScene(nextIndex);
        }

        if(col.gameObject.CompareTag("Door") && hasKey == false)
        {
            Debug.Log("Door is locked");
        }
    }

}
