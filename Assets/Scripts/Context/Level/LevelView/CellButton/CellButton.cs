using UnityEngine;
using UnityEngine.UI;
using TMPro;
using strange.extensions.mediation.impl;
using System;

/// <summary>
/// Кнопка для поля
/// </summary>
public class CellButton : MonoBehaviour
{
    private int _cellInt;
    private char _cellChar;
    public CellState State { get; set; } = CellState.Empty;
    [SerializeField] private TMP_Text _buttonText;
    [SerializeField] private Button _buttonElement;
    [SerializeField] private AllTowersView _towers;

    public event Action<CellButton> OnCellButtonClick = delegate { };
    public int CellInt
    {
        get => _cellInt;
        set => _cellInt = value;
    }
    public char CellChar
    {
        get => _cellChar;
        set => _cellChar = value;
    }
    public TMP_Text ButtonText
    {
        get => _buttonText;
        set => _buttonText = value;
    }
    public Button ButtonElement
    {
        get => _buttonElement;
        set => _buttonElement = value;
    }

    private void OnEnable()
    {
        _buttonElement.onClick.AddListener(delegate
        {
            OnCellButtonClick?.Invoke(this);
        });
    }
}

public enum CellState
{
    Empty,
    HasTower,
    EnemyWay
}