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
    GameObject login;
    void Awake()
    {
        Transform canvas = UnityEngine.Object.FindObjectOfType<Canvas>().transform;
        login = UnityEngine.Object.Instantiate(Resources.Load<GameObject>("Panel"), canvas);
        login.GetComponentInChildren<Button>().onClick.AddListener(afterLogin);

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

    public void afterLogin()
    {


        Button gameObject;
        Button button;
        Transform canvas = UnityEngine.Object.FindObjectOfType<Canvas>().transform;
        gameObject = Resources.Load<Button>("Restart");
        button = UnityEngine.Object.Instantiate(gameObject, canvas);
        button.onClick.AddListener(Reload);

        saver = new Saver(login.GetComponentInChildren<InputField>().text+".txt");

        gameObject = Resources.Load<Button>("Load");
        button = UnityEngine.Object.Instantiate(gameObject, canvas);
        button.onClick.AddListener(saver.Load);

        gameObject = Resources.Load<Button>("Save");
        button = UnityEngine.Object.Instantiate(gameObject, canvas);
        button.onClick.AddListener(saver.Save);

        gameObject = Resources.Load<Button>("ScreenShot");
        button = UnityEngine.Object.Instantiate(gameObject, canvas);
        button.onClick.AddListener(ScreenShot);

        login.SetActive(false);
    }
}

