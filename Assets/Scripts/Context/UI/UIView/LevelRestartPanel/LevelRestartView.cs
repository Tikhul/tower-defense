using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LevelRestartView : BaseView
{
    [SerializeField] private Button _restartButton;
    [SerializeField] private Button _nextLevelButton;

    public event Action OnRestartClick = delegate { };
    public event Action OnNextClick = delegate { };

    private void OnEnable()
    {
        _restartButton.onClick.AddListener(delegate
            {
                OnRestartClick?.Invoke();
            });
        _nextLevelButton.onClick.AddListener(delegate
        {
            OnNextClick?.Invoke();
        });
    }
}
