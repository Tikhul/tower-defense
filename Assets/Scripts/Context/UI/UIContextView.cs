using strange.extensions.context.impl;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIContextView : ContextView
{
    void Start()
    {
        context = new UIContext(this);
        //context.Start();
    }
}

