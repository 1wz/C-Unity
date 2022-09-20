using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class PlayerAbstract : MonoBehaviour
{
    [SerializeField]
    float Forse = 5f;
    [HideInInspector]
    public float forse;
    

    protected Rigidbody RB;

    Vector3 Respawn;
    void Awake()
    {
        RB = GetComponent<Rigidbody>();
        Respawn = transform.position;
        forse = Forse;
    }

    public  void Die()
    {
        transform.position = Respawn;
        RB.velocity = new Vector3(0, 0, 0);
        forse = Forse;
    }
}
