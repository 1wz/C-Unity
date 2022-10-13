using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Speed : MonoBehaviour,IDestroy, IDisposable
{
    [SerializeField]
    float ForceUp = 5;

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
        other.GetComponent<PlayerAbstract>().forse+=Mathf.Sign(other.GetComponent<PlayerAbstract>().forse)*ForceUp;
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
