using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreView : MonoBehaviour,IDisposable
{
    private Text score;

    private void Awake()
    {
        score = GetComponent<Text>();
        Score.OnTakeBonus += AddScore;
        Controller.OnReload += Reload;
        PlayerAbstract.OnWin += ShowWin;
        PlayerAbstract.OnDie += ShowDie;
    }

    public void AddScore(int t, PlayerAbstract PA)
    {
        score.text +=PA.gameObject.name+" заработал +"+ t.ToString()+" очков\n";
    }

    private void ShowWin(PlayerAbstract PA)
    {
        score.text += PA.gameObject.name + " прошел уровень\n";
    }

    private void ShowDie(PlayerAbstract PA)
    {
        score.text += PA.gameObject.name + " умер\n";
    }
    public void Reload()
    {
        score.text = "";
    }

    private void OnDestroy()
    {
        Dispose();
    }

    public void Dispose()
    {
        Score.OnTakeBonus -= AddScore;
        Controller.OnReload -= Reload;
    }
}
