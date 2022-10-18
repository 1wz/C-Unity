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
        score.text +="� ������ " + cort.Item1 + " "+ cort.Item2+" �����\n";
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
        score.text +=PA.gameObject.name+" ��������� +"+ t.ToString()+" �����\n";
    }

    private void ShowWin(PlayerAbstract PA)
    {
        score.text += PA.gameObject.name + " ������ ������� �� ������ "+PA.score+"\n";
    }

    private void ShowDie(PlayerAbstract PA)
    {
        score.text += PA.gameObject.name + " ���� �� ������ "+PA.score+"\n";
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
        score.text +="���� ���������\n";
        return SaveParam;
    }

    public void Load(ArrayList SaveParam)
    {
        score.text=((string)SaveParam[0] + "���� ���������\n");
    }
}
