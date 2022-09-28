using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraShake : MonoBehaviour,IDisposable
{
    [SerializeField]
    float TimeScale = 1f;
    [SerializeField]
    float Power = 0.01f;
    Vector3 DefoltPos;
    void Awake()
    {
        PlayerAbstract.OnDie += Shake;
        DefoltPos = transform.position;
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
            transform.position = DefoltPos + Delta * timer / TimeScale;

            timer -= Time.deltaTime;
            yield return null;
        }
        transform.position = DefoltPos;
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
