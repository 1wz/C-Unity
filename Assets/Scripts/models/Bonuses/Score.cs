using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Score : MonoBehaviour,IDestroy, IDisposable
{
    [SerializeField]
    int Profit;

    public static event Action<int,PlayerAbstract> OnTakeBonus;

    private void Awake()
    {
        Controller.OnReload += Reload;
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent<PlayerAbstract>(out var PV))
        {
            PV.AddScore(Profit);
            OnTakeBonus?.Invoke(Profit,PV);
            Destroy();
        }
    }

    public void Destroy()
    {
        gameObject.SetActive(false);
    }

    public void Reload()
    {
        gameObject.SetActive(true);
    }

    private void OnDestroy()
    {
        Dispose();
    }
    public void Dispose()
    {
        Controller.OnReload -= Reload;
    }
    public ArrayList Save()
    {
        ArrayList SaveParam = new();
        SaveParam.Add(gameObject.activeSelf);
        return SaveParam;
    }

    public void Load(ArrayList SaveParam)
    {
        gameObject.SetActive((bool)SaveParam[0]);
    }
}
