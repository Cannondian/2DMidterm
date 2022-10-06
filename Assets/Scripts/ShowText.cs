using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ShowText : MonoBehaviour
{

    public string textValue;
    public TMP_Text textElement;

    // Start is called before the first frame update
    void Start()
    {
        textElement.text = textValue;
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
