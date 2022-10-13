using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public interface IDestroy:ISaveble
{
    void Destroy();
    void Reload();
}

public interface ISaveble
{
    public ArrayList Save();
    public void Load(ArrayList data);
}

