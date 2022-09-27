using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Death : MonoBehaviour
{

    private int index;

    // Start is called before the first frame update
    void Start()
    {
        index = SceneManager.GetActiveScene().buildIndex;

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        if(col.gameObject.CompareTag("Enemy")){
            Debug.Log("Enemy killed you");
            SceneManager.LoadScene(index);
        }

        if(col.gameObject.CompareTag("DeathObstacle")){
            Debug.Log("Ran into deadly obstacle");
            SceneManager.LoadScene(index);
        }
    }
}
