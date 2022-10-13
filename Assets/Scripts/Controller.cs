using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.UI;

public class Controller : MonoBehaviour
{
 
    public static event Action OnReload;
    Saver saver;
    void Awake()
    {
        Button gameObject;
        Button button;
        Transform canvas = UnityEngine.Object.FindObjectOfType<Canvas>().transform;
        gameObject = Resources.Load<Button>("Restart");
        button = UnityEngine.Object.Instantiate(gameObject,canvas);
        button.onClick.AddListener(Reload);

        saver = new Saver("save.txt");

        gameObject = Resources.Load<Button>("Load");
        button = UnityEngine.Object.Instantiate(gameObject, canvas);
        button.onClick.AddListener(saver.Load);

        gameObject = Resources.Load<Button>("Save");
        button = UnityEngine.Object.Instantiate(gameObject, canvas);
        button.onClick.AddListener(saver.Save);

        gameObject = Resources.Load<Button>("ScreenShot");
        button = UnityEngine.Object.Instantiate(gameObject, canvas);
        button.onClick.AddListener(ScreenShot);
    }


    public static void Reload()
    {
        OnReload?.Invoke();
    }

    public void ScreenShot()
    {
        var filename = string.Format("{0:ddMMyyyy_HHmmssfff}.png", DateTime.Now);
        ScreenCapture.CaptureScreenshot(Path.Combine(Application.dataPath, filename));
    }

}

