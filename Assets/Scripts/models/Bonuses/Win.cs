using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Win : MonoBehaviour,IDestroy
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent<PlayerAbstract>(out var PA))
        {
            PA.Win();
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
