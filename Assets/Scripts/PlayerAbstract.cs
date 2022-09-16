using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class PlayerAbstract : MonoBehaviour
{
    
    public float Forse = 5f;

    protected Rigidbody RB;

    Vector3 Respawn;
    void Awake()
    {
        RB = GetComponent<Rigidbody>();
        Respawn = transform.position;
    }

    public  void Die()
    {
        IDestroy.Refresh();
        IScore.Refresh();
        transform.position = Respawn;
        RB.velocity = new Vector3(0, 0, 0);
    }
}
