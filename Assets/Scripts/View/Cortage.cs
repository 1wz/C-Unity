using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cortage : MonoBehaviour,IDestroy
{
    private void Awake()
    {
        Controller.OnReload += Reload;
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent<PlayerAbstract>(out var PA))
        {
            (string  name, int score) cortage = (PA.gameObject.name, PA.score);
            ScoreView.cortage(cortage);
            Destroy();
        }
    }

    public void Destroy()
    {
        gameObject.SetActive(false);
    }

    public void Reload()
    {
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
        return SaveParam;
    }

    public void Load(ArrayList SaveParam)
    {
        gameObject.SetActive((bool)SaveParam[0]);
    }
}
