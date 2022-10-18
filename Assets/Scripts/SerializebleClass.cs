using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using UnityEngine;



public class Saver
{
    string dataPath;
    Dictionary<string, ISaveble> SaveList = new Dictionary<string, ISaveble>();

    public Saver(string fileName)
    {
        var savelist = UnityEngine.Object.FindObjectsOfType<MonoBehaviour>().OfType<ISaveble>().ToArray();
        try
        {
            foreach (var s in savelist)
            {
                MonoBehaviour _s = (MonoBehaviour)s;
                SaveList.Add(_s.gameObject.name + nameof(_s), s);
            }
        }
        catch (System.ArgumentException)
        {
            Debug.Log("the objects have the same names");
        }
        dataPath= Path.Combine(Application.streamingAssetsPath, fileName);
    }

    public void Save()
    {
        Dictionary<string, ArrayList> SaveData=new();
        foreach(var s in SaveList)
        {
            SaveData.Add(s.Key, s.Value.Save());
        }

        BinaryFormatter formatter = new BinaryFormatter();
        using (var fs = new FileStream(dataPath, FileMode.Create))
        {
            formatter.Serialize(fs, SaveData);
        }
    }

    public void Load()
    {
        if (!File.Exists(dataPath))
        {
            Debug.Log("savefile not found  "+dataPath);
            return;
        }

        BinaryFormatter formatter = new BinaryFormatter();
        Dictionary<string, ArrayList> SaveData;
        using (var fs = new FileStream(dataPath, FileMode.Open))
        {
            SaveData = (Dictionary<string, ArrayList>)formatter.Deserialize(fs);
        }
        
        foreach(var s in SaveList)
        {
            if (SaveData.ContainsKey(s.Key))
            {
                s.Value.Load(SaveData[s.Key]);
            }
        }
    }
}
