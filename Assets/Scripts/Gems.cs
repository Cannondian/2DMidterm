using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class Gems : MonoBehaviour
{

    public TMP_Text MygemText;
    private int GemNum;
    private CoinCollector cc;

    // Start is called before the first frame update
    void Start()
    {
        // MygemText = GetComponent<TMP_Text>();
        cc = CoinCollector.GetInstance();
        GemNum = cc.GetScore();
        MygemText.text = GemNum.ToString();

    }
    /*
    private void OnTriggerEnter2D(Collider2D Diamond)
    {
        if (Diamond.tag == "MyDiamond")
        {
            GemNum += 1;
            //Destroy(Diamond.gameObject);
            MygemText.text = "Gem" + GemNum;
        }

    }
    */

    private void Update()
    {
        GemNum = cc.GetScore();
        MygemText.text = GemNum.ToString();
    }
}
