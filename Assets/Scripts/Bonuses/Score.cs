using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Score : MonoBehaviour,IScore,IDestroy
{
    [SerializeField]
    int Profit;

    Text ScoreText;



    private void OnTriggerEnter(Collider other)
    {
        AddScore(Profit);
        Destroy();
    }

    public void Destroy()
    {
        gameObject.SetActive(false);
    }


    public void AddScore(int profit)
    {
        ScoreText.text = (Int32.Parse(ScoreText.text) + profit).ToString();
    }

    public void DetectText(Text text)
    {
        ScoreText = text;
    }

    public void Reload()
    {
        gameObject.SetActive(true);
    }
}
