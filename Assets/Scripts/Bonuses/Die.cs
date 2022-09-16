using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Die : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent<PlayerAbstract>(out _))
        {
            other.GetComponent<PlayerAbstract>().Die();
        }
    }
}
