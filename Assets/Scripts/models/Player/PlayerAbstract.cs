using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class PlayerAbstract : MonoBehaviour, IDisposable,ISaveble
{
    [SerializeField]
    float Forse = 5f;
    [HideInInspector]
    public float forse;
    public int score = 0;


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

    public void AddScore(int t)
    {
        score+=t;
    }

    public void Reload()
    {
        transform.position = Respawn;
        RB.velocity = new Vector3(0, 0, 0);
        forse = Forse;
        score = 0;
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

    public ArrayList Save()
    {
        ArrayList SaveParam = new();
        SaveParam.Add(gameObject.activeSelf);
        SaveParam.Add(score);
        SaveParam.Add(transform.position.x);
        SaveParam.Add(transform.position.y);
        SaveParam.Add(transform.position.z);
        SaveParam.Add(forse);
        return SaveParam;
    }

    public void Load(ArrayList SaveParam)
    {
        gameObject.SetActive((bool)SaveParam[0]);
        score = (int)SaveParam[1];
        transform.position = new Vector3((float)SaveParam[2],(float)SaveParam[3],(float)SaveParam[4]);
        forse = (float)SaveParam[5];

    }
}
