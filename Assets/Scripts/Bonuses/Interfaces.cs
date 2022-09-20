using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public interface IScore
{
    void DetectText(Text t);
    void AddScore(int cout);
}

public interface IDestroy
{
    void Destroy();
    void Reload();
}

