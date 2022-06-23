using strange.extensions.mediation.impl;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MenuView : BaseView
{
    [SerializeField] private Button _closeButton;

    public event Action OnCloseMenu = delegate { };

    private void OnEnable()
    {
        _closeButton.onClick.AddListener(delegate
        {
            OnCloseMenu?.Invoke();
        });
    }
}
