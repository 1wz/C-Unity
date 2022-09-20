using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraShake : MonoBehaviour
{
    [SerializeField]
    float TimeScale = 1f;
    [SerializeField]
    float Power = 0.01f;
    Vector3 DefoltPos;
    void Start()
    {

        DefoltPos = transform.position;
    }

public void Shake()
    {
        if(TimeScale>0)
        StartCoroutine(Shaker());
    }

    private IEnumerator Shaker()
    {
        //Счетчик прошедшего времени
        float timer = TimeScale;
        Vector3 Delta = new Vector3(0, 0, 0);
        while (timer >0)
        {
            Delta += Random.insideUnitSphere * Power;
            transform.position = DefoltPos + Delta * timer / TimeScale;

            timer -= Time.deltaTime;
            yield return null;
        }
        //Восстанавливаем вращение
        transform.position = DefoltPos;
    }
}
