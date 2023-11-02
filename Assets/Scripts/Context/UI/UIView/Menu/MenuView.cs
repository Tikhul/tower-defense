using System;
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
