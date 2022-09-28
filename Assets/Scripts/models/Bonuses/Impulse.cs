using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Impulse : MonoBehaviour
{
    [SerializeField]
    float ValueImp = 10f;

    private void OnTriggerStay(Collider other)
    {
        if (other.TryGetComponent<PlayerAbstract>(out _))
        {
            other.GetComponent<Rigidbody>().AddForce(-transform.right * ValueImp);
        }
    }
}
