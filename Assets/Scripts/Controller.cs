using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Controller : MonoBehaviour
{

    Button button;
    
    public static event Action OnReload;
    void Awake()
    {
        var gameObject = Resources.Load<Button>("Button (Legacy)");
        button = UnityEngine.Object.Instantiate(gameObject, UnityEngine.Object.FindObjectOfType<Canvas>().transform);
        button.onClick.AddListener(Reload);

    }

    public static void Reload()
    {
        OnReload?.Invoke();
    }

    
}
