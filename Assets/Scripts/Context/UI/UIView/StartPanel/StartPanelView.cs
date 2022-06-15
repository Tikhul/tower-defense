using strange.extensions.mediation.impl;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StartPanelView : View
{
    [SerializeField] private Button _startButton;

    public event Action OnStartButtonClick = delegate { };

    private void OnEnable()
    {
        _startButton.onClick.AddListener(delegate
        {
            OnStartButtonClick?.Invoke();
        });
    }

    public void Hide()
    {
        gameObject.SetActive(false);
    }
}
