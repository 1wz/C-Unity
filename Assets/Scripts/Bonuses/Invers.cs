using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Invers : MonoBehaviour, IControl, IDestroy
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
        other.GetComponent<PlayerAbstract>().Forse *=(-1f);
    }

    public void Destroy()
    {
        IDestroy.IfDie.Add(this);
        gameObject.SetActive(false);
    }
    public void RefreshIt()
    {
        gameObject.SetActive(true);
    }
}
