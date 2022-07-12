using strange.extensions.context.impl;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameContextView : ContextView
{
    void Start()
    {
        context = new GameContext(this);
        //context.Start();
    }
}