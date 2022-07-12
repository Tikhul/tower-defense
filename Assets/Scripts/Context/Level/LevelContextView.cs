using strange.extensions.context.impl;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelContextView : ContextView
{
    void Start()
    {
        context = new LevelContext(this);
        //context.Start();
    }
}