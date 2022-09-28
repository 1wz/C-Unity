using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class PlayerAbstract : MonoBehaviour, IDisposable
{
    [SerializeField]
    float Forse = 5f;
    [HideInInspector]
    public float forse;
    
    protected Rigidbody RB;
    Vector3 Respawn;

    public static event Action<PlayerAbstract> OnWin;
    public static event Action<PlayerAbstract> OnDie;
    void Awake()
    {
        RB = GetComponent<Rigidbody>();
        Respawn = transform.position;
        forse = Forse;
        Controller.OnReload += Reload;
    }

    public void Win()
    {
        gameObject.SetActive(false);
        OnWin?.Invoke(this);
    }

    public void Die()
    {
        gameObject.SetActive(false);
        OnDie?.Invoke(this);
    }

    public void Reload()
    {
        transform.position = Respawn;
        RB.velocity = new Vector3(0, 0, 0);
        forse = Forse;
        gameObject.SetActive(true);
    }

    private void OnDestroy()
    {
        Dispose();
    }
    public void Dispose()
    {
        Controller.OnReload -= Reload;
    }
}
