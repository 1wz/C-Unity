using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public interface IDestroy:IDisposable
{
    void Destroy();
    void Reload();
}

public interface ISaveble
{

}

