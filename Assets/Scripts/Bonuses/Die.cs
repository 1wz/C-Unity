using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Die : MonoBehaviour
{
    public delegate void OnDie();
    public event OnDie ondie;


    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent<PlayerAbstract>(out _))
        {
            ondie?.Invoke();
        }
    }
}
