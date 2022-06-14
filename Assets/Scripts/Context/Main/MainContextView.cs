using strange.extensions.context.impl;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainContextView : ContextView
{
    void Start()
    {
        var context = new MainContext(this);
        context.Start();
    }
}
