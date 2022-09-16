using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public interface IScore
{
    static Text ScoreText;

    static void AddScore(int profit)
    {
        ScoreText.text = (Int32.Parse(ScoreText.text) + profit).ToString();
    }

    static void Refresh()
    {
        ScoreText.text = "0";
    }
}

public interface IDestroy
{
    static List<IDestroy> IfDie=new List<IDestroy>();
    void Destroy();
    void RefreshIt();
    static void Refresh()
    {
        foreach(var I in IfDie)
        {
            I.RefreshIt();
        }
        IfDie.Clear();
    }
}

public interface IControl
{
   void SetForce(Collider oth);
}
