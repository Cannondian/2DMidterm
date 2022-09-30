using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : MonoBehaviour
{
    /*
    //animation tools
    private float timer = 0;
    private int currFrame = 0;
    private int fps = 50;
    private SpriteRenderer sr;
    public Sprite[] frames;
    */

    // Start is called before the first frame update
    void Start()
    {
        //sr = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        /*
        timer -= Time.deltaTime;
        if(timer <= 0.0f)
        {
            timer = 1 / fps;
            currFrame %= frames.Length; //taken from "Level Design" code + tutorial
            sr.sprite = frames[currFrame];
            currFrame++;
        }
        */
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        // PlayerController player = other.gameObject.GetComponent<PlayerController>();
        if (other.gameObject.GetComponent<PlayerController>() != null)
        {
            //increase score
            CoinCollector cc = CoinCollector.GetInstance();
            cc.IncreaseScore();
            //destroy current coin
            Destroy(gameObject);
        }
    }
}
