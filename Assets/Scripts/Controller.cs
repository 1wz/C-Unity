using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Controller : MonoBehaviour
{
 
    public static event Action OnReload;
    SerializebleClass SaveClass = new SerializebleClass();
    void Awake()
    {
        Button gameObject;
        Button button;
        Transform canvas = UnityEngine.Object.FindObjectOfType<Canvas>().transform;
        gameObject = Resources.Load<Button>("Restart");
        button = UnityEngine.Object.Instantiate(gameObject,canvas);
        button.onClick.AddListener(Reload);

        gameObject = Resources.Load<Button>("Load");
        button = UnityEngine.Object.Instantiate(gameObject, canvas);
        button.onClick.AddListener(Reload);

        gameObject = Resources.Load<Button>("Save");
        button = UnityEngine.Object.Instantiate(gameObject, canvas);
        button.onClick.AddListener(Reload);


        GameObject[] savelist = UnityEngine.Object.FindObjectsOfType<IDisposable>();
    }

    public static void Reload()
    {
        OnReload?.Invoke();
    }

    public void Save()
    {
        
    }

    public void Load()
    {

    }
}
