using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class PlayerAbstract : MonoBehaviour
{
    public float Forse = 5f;

    [HideInInspector]
    public Rigidbody RB;

    void Awake()
    {
        RB = GetComponent<Rigidbody>();
    }

    void Die()
    {

    }
}
