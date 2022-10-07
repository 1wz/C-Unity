using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraManager : MonoBehaviour,IDisposable
{
    [SerializeField]
    float TimeScale = 1f;
    [SerializeField]
    float Power = 0.01f;
    Vector3 DefoltPos;
    PlayerAbstract[] Players;
    float[] WaightsOfPlayers;
    float SumWaights;
    Vector3 center;
    Vector3 ShakeVec = Vector3.zero;
    [SerializeField]
    float RadiusOfCamera=2f;
    void Awake()
    {
        PlayerAbstract.OnDie += Shake;
        DefoltPos = transform.position;

        Players = FindObjectsOfType<PlayerAbstract>();
        WaightsOfPlayers = new float[Players.Length];
        SetWaights();

        center = GetCenter();//
        DefoltPos = transform.position-center;
    }

    private void Update()
    {
        SetWaights();
        center = GetCenter();
        float rad = GetMaxRadius();
        transform.position = center + (rad < RadiusOfCamera ? DefoltPos: DefoltPos* rad/RadiusOfCamera)+ShakeVec;
    }
    public void Shake(PlayerAbstract PA)
    {
        if(TimeScale>0)
        StartCoroutine(Shaker());
    }

    private IEnumerator Shaker()
    {
        float timer = TimeScale;
        Vector3 Delta = new Vector3(0, 0, 0);
        while (timer >0)
        {
            Delta += UnityEngine.Random.insideUnitSphere * Power;
            ShakeVec= Delta * timer / TimeScale;

            timer -= Time.deltaTime;
            yield return null;
        }
        ShakeVec=Vector3.zero;
    }

    private void SetWaights()
    {
        for(int i=0; i< WaightsOfPlayers.Length; i++)
        {
            WaightsOfPlayers[i] = 0f;
        }
        SumWaights = 0f;

        for(int i=0; i< WaightsOfPlayers.Length - 1; i++)
        {
            for(int k = i + 1; k < WaightsOfPlayers.Length; k++)
            {
                float waight = Vector3.Distance(Players[i].transform.position, Players[k].transform.position);
                WaightsOfPlayers[i] += waight;
                WaightsOfPlayers[k] += waight;
                SumWaights+=waight;
            }
        }
        SumWaights *= 2;
    }

    private Vector3 GetCenter()
    {
        Vector3 center = new Vector3(0,0,0);
        for (int i = 0; i < WaightsOfPlayers.Length; i++)
        {
            center += Players[i].transform.position * WaightsOfPlayers[i];
        }
        center /= SumWaights;

        return center;
    }

    private float GetMaxRadius()
    {
        float rad = 0f;
        for (int i = 0; i < WaightsOfPlayers.Length; i++)
        {
            float r = Vector3.Distance(center, Players[i].transform.position);
            if (r > rad) rad = r;
        }
        return rad;
    }

    private void OnDestroy()
    {
        Dispose();
    }
    public void Dispose()
    {
        PlayerAbstract.OnDie -= Shake;
    }
}
