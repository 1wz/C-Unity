using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Invers : MonoBehaviour,  IDestroy
{
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
}
