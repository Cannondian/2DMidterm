using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildLadder : MonoBehaviour
{

    //public GameObject finalLadder;
    private GameObject temp;
    private GameObject adult;
    private GameObject child;
    

    private bool buildPossible = false;

    public SpriteRenderer rend;

    // Start is called before the first frame update
    void Start()
    {
        
        child = transform.GetChild(0).gameObject;
        child.SetActive(false);

        rend = GetComponent<SpriteRenderer>();

    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.M) && buildPossible == false)
        {
            Debug.Log("M pressed, can't build'");
        }
        if(buildPossible == true)
        {
            if(Input.GetKeyDown(KeyCode.M))
            {
                Debug.Log("M pressed, build possible");
                //adult.SetActive(false);
                child.SetActive(true);
                buildPossible = false;
                rend.enabled = false;
            }   
        }
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        if(col.gameObject.CompareTag("Player"))
        {
            buildPossible = true;
            //adult = col.gameObject;
            

            
        }
    }

    void OnTriggerExit2D(Collider2D col)
    {
        if(col.gameObject.CompareTag("Player"))
        {
            buildPossible = false;
        }
    }
}
