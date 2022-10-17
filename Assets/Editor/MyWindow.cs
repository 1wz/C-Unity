using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using System.Linq;

public class MyWindow : EditorWindow
{
    //public static GameObject[] Objects;

    private void OnGUI()
    {
        GameObject[] gos = (GameObject[])GameObject.FindObjectsOfType(typeof(GameObject));
        GUILayout.Label("Количество объектов на сцене: "+gos.Length.ToString(), EditorStyles.boldLabel);

        var IsPartOfAnyPrefab = from g in gos where PrefabUtility.IsPartOfAnyPrefab(g) select g;
        GUILayout.Label("Количество IsPartOfAnyPrefab: " + IsPartOfAnyPrefab.Count().ToString(), EditorStyles.boldLabel);

        var IsPartOfPrefabInstance = from g in gos where PrefabUtility.IsPartOfPrefabInstance(g) select g;
        GUILayout.Label("Количество IsPartOfPrefabInstance: " + IsPartOfPrefabInstance.Count().ToString(), EditorStyles.boldLabel);

        var IsPartOfPrefabAsset = from g in gos where PrefabUtility.IsPartOfPrefabAsset(g) select g;
        GUILayout.Label("Количество IsPartOfPrefabAsset: " + IsPartOfPrefabAsset.Count().ToString(), EditorStyles.boldLabel);
    }
}

