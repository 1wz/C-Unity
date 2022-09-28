using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Speed : MonoBehaviour,IDestroy
{
    [SerializeField]
    float ForceUp = 5;
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
        Debug.Log("Успех");
    }
}
