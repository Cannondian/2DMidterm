using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Signpost : MonoBehaviour
{
    public TMP_Text textbox;

    private void Start()
    {
        textbox.alignment = TextAlignmentOptions.Center;
        textbox.color = Color.white;
        textbox.text = "";
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log("Collided!");
        textbox.text = "Sorry about our hospital infrastructure.\nPress M to build a ladder.";
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        textbox.text = "";
    }

    /*
    private void OnCollisionEnter2D(Collision2D other)
    {
        Debug.Log("Collided!");
        textbox.text = "Sorry about our infrastructure.\nPress M to build a ladder.";
        if (other.gameObject.GetComponent<PlayerController>() != null)
        {
            textbox.text = "Sorry about our infrastructure.\nPress M to build a ladder.";
        }
    }
    private void OnCollisionExit2D(Collision2D other)
    {
        textbox.text = "";
       
        if (other.gameObject.GetComponent<PlayerController>() != null)
        {
            textbox.text = "";
        }
    }
    */

}
