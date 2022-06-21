using strange.extensions.mediation.impl;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelView : BaseView
{
    public event Action OnSpaceClick = delegate { };
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            OnSpaceClick?.Invoke();
        }
    }
}
