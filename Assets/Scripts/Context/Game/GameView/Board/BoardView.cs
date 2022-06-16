using strange.extensions.mediation.impl;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoardView : View
{
    [SerializeField] private GameObject _boardParent;

    public event Action OnBoardViewActivated = delegate { };
    public GameObject BoardParent
    {
        get => _boardParent;
        set => _boardParent = value;
    }

    private void OnEnable()
    {
        OnBoardViewActivated?.Invoke();
    }
}
