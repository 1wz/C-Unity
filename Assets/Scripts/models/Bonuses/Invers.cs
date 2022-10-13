using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Invers : MonoBehaviour,  IDestroy,IDisposable
{
    private void Awake()
    {
        Controller.OnReload += Reload;
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent<PlayerAbstract>(out _))
        {
            SetForce(other);
            Destroy();
        }
    }

    public void SetForce(Collider other)
    {
        other.GetComponent<PlayerAbstract>().forse *=(-1f);
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
