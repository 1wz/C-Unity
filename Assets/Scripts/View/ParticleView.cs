using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParticleView : MonoBehaviour,IDisposable
{
    ParticleSystem parts;
    private void Awake()
    {
        PlayerAbstract.OnDie += Play;
        PlayerAbstract.OnWin += Play;
        parts = GetComponent<ParticleSystem>();
    }

    private void Play(PlayerAbstract PA)
    {
        parts.transform.position = PA.transform.position;
        parts.Play();
    }

    private void OnDestroy()
    {
        Dispose();
    }
    public void Dispose()
    {
        PlayerAbstract.OnDie -= Play;
        PlayerAbstract.OnWin -= Play;
    }
}
