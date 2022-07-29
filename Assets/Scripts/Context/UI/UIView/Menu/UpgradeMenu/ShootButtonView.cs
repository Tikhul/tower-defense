using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShootButtonView : BaseView
{
    [SerializeField] private Button _shootButton;
    public Button ShootButton => _shootButton;

    public event Action OnShootButtonClicked = delegate { };
    private void OnEnable()
    {
        _shootButton.onClick.AddListener(OnClickHandler);
    }
    private void OnDisable()
    {
        _shootButton.onClick.RemoveListener(OnClickHandler);
    }
    private void OnClickHandler()
    {
        OnShootButtonClicked?.Invoke();
    }
    public void BlockButton()
    {
        _shootButton.interactable = false;
    }
    public void UnblockButton()
    {
        _shootButton.interactable = true;
    }
}
