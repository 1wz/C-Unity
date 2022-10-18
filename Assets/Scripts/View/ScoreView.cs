using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreView : MonoBehaviour,IDisposable,ISaveble
{
    private Text score;

    static public Action<(string, int)> cortage;//

    public void ViewCortage((string, int) cort)//
    {
        score.text +="у игрока " + cort.Item1 + " "+ cort.Item2+" очков\n";
    }
    private void Awake()
    {
        score = GetComponent<Text>();
        Score.OnTakeBonus += AddScore;
        Controller.OnReload += Reload;
        PlayerAbstract.OnWin += ShowWin;
        PlayerAbstract.OnDie += ShowDie;
        cortage += ViewCortage;//
    }

    public void AddScore(int t, PlayerAbstract PA)
    {
        score.text +=PA.gameObject.name+" заработал +"+ t.ToString()+" очков\n";
    }

    private void ShowWin(PlayerAbstract PA)
    {
        score.text += PA.gameObject.name + " прошел уровень со счетом "+PA.score+"\n";
    }

    private void ShowDie(PlayerAbstract PA)
    {
        score.text += PA.gameObject.name + " умер со счетом "+PA.score+"\n";
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
        PlayerAbstract.OnWin -= ShowWin;
        PlayerAbstract.OnDie -= ShowDie;
    }

    public ArrayList Save()
    {
        ArrayList SaveParam = new();
        SaveParam.Add(score.text);
        score.text +="игра сохранена\n";
        return SaveParam;
    }

    public void Load(ArrayList SaveParam)
    {
        score.text=((string)SaveParam[0] + "игра загружена\n");
    }
}
