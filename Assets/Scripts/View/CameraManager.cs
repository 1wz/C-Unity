using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class CameraManager : MonoBehaviour,IDisposable
{
    [SerializeField]
    float TimeScale = 1f;
    [SerializeField]
    float Power = 0.01f;
    Vector3 DefoltHeight;
    TransWaight[] Players;
    float SumWaights;
    Vector3 center;
    Vector3 ShakeVec = Vector3.zero;
    [SerializeField]
    float RadiusOfCamera=2f;
    float rad=0f;
    void Awake()
    {

        PlayerAbstract.OnDie += Shake;

        var players = FindObjectsOfType<PlayerAbstract>();
        Players = new TransWaight[players.Length];
        for(int i = 0; i< players.Length; i++)
        {
            Players[i]= new TransWaight(players[i].transform, 0);
        }


        SetWaights();
        center = Players[0].Trans.position;
        center = GetCenter();
        DefoltHeight = transform.position-center;
        //RadiusOfCamera=(float)Math.Tan(Camera.main.fieldOfView * Mathf.Deg2Rad) * Vector3.Magnitude(DefoltHeight)/4;

    }

    private void Update()
    {
        SetWaights();
        center = GetCenter();
        rad= GetMaxRadius();
        transform.position = center + (rad < RadiusOfCamera ? DefoltHeight : DefoltHeight * rad/RadiusOfCamera)+ShakeVec;
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
        var enableList = from n in Players where n.Trans.gameObject.activeSelf select n;
        int elCount = enableList.Count();
        for (int i=0; i< Players.Length; i++)
        {
            Players[i].Waight = 0f;
        }
        SumWaights = 0f;

        if (elCount == 0) return;
        if (elCount == 1)
        {
            enableList.ElementAt(0).Waight = 1f;
            SumWaights = 1f;
            return;
        }

        for(int i=0; i<elCount  - 1; i++)
        {
            for(int k = i + 1; k < elCount; k++)
            {
                    float waight = Vector3.Distance(Players[i].Trans.position, Players[k].Trans.position);
                    Players[i].Waight += waight;
                    Players[k].Waight += waight;
                    SumWaights += waight;
            }
        }
        SumWaights *= 2;
    }

    private Vector3 GetCenter()
    {
        if (SumWaights == 0) return this.center;
        Vector3 center = new Vector3(0,0,0);
        for (int i = 0; i < Players.Length; i++)
        {
            center += Players[i].Trans.position * Players[i].Waight;
        }
        center /= SumWaights;

        return center;
    }

    private float GetMaxRadius()
    {
        float rad = 0f;
        for (int i = 0; i < Players.Length; i++)
        {
            if (Players[i].Trans.gameObject.activeSelf)
            {
                float r = Vector3.Distance(center, Players[i].Trans.position);
                if (r > rad) rad = r;
            }
        }
        return rad ;
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

public class TransWaight
{
    public Transform Trans;
    public float Waight;
    public TransWaight(Transform tran, float wai)
    {
        Trans = tran;
        Waight = wai;
    }
}
