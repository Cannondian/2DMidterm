using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinCollector : MonoBehaviour
{
    public static CoinCollector instance;
    public int score;

    private void Awake()
    {
        instance = this;
        score = 0;
    }

    public static CoinCollector GetInstance()
    {
        return instance;
    }

    public void IncreaseScore()
    {
        score++;
    }

    public int GetScore()
    {
        return score;
    }

}
