using System;
using UnityEngine;
using UnityEngine.UI;

public class StartPanelView : BaseView
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
}
