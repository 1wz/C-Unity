using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Score : MonoBehaviour,IDestroy
{
    [SerializeField]
    int Profit;

    public static event Action<int,PlayerAbstract> OnTakeBonus;

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
        Controller.OnReload += Reload;
    }

    public void Reload()
    {
        gameObject.SetActive(true);
        Controller.OnReload -= Reload;

    }

    private void OnDestroy()
    {
        Dispose();
    }
    public void Dispose()
    {
        Controller.OnReload -= Reload;
    }
}
