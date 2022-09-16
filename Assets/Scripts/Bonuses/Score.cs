using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Score : MonoBehaviour,IScore,IDestroy
{
    [SerializeField]
    int Profit;
    [SerializeField]
    Text ScoreUI;

    private void Start()
    {
        IScore.ScoreText = ScoreUI;
    }

    private void OnTriggerEnter(Collider other)
    {
        IScore.AddScore(Profit);
        Destroy();
    }

    public void Destroy()
    {
        
        IDestroy.IfDie.Add(this);
        gameObject.SetActive(false);
    }

    public void RefreshIt()
    {
        gameObject.SetActive(true);
    }
}
