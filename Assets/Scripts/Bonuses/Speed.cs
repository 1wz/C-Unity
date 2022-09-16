using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Speed : MonoBehaviour,IControl,IDestroy
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
        other.GetComponent<PlayerAbstract>().Forse+=Mathf.Sign(other.GetComponent<PlayerAbstract>().Forse)*ForceUp;
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
