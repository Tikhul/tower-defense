using UnityEngine;
using UnityEngine.UI;
using strange.extensions.mediation.impl;
using System;

/// <summary>
/// Кнопка для поля
/// </summary>
public class CellButtonView : View
{
    private int _cellInt;
    private char _cellChar;
    public CellState State { get; set; } = CellState.Empty;
    public int OrderIndex { get; set; }
    [SerializeField] private Button _buttonElement;
    [SerializeField] private AllTowersView _towers;
    [SerializeField] private AllEnemiesView _enemies;

    public event Action<CellButtonView> OnCellButtonViewClick = delegate { };
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
    public AllTowersView Towers
    {
        get => _towers;
        set => _towers = value;
    }
    public AllEnemiesView Enemies
    {
        get => _enemies;
        set => _enemies = value;
    }
    private void OnEnable()
    {
        _buttonElement.onClick.AddListener(delegate
        {
            OnCellButtonViewClick?.Invoke(this);
        });
    }
    public void BlockButton()
    {
        _buttonElement.interactable = false;
    }
    public void UnblockButton()
    {
        if (!State.Equals(CellState.EnemyWay))
        {
            _buttonElement.interactable = true;
        }
    }
    public void ClearButton()
    {
        if (State.Equals(CellState.HasTower))
        {
            foreach(var tower in Towers.TowerViews)
            {
                tower.gameObject.SetActive(false);
            }
        }
    }
    public void DrawEnemyWay()
    {
        if (State.Equals(CellState.EnemyWay))
        {
            _buttonElement.interactable = false;
            GetComponent<Image>().color = Color.blue;
        }
        else
        {
            _buttonElement.interactable = true;
            GetComponent<Image>().color = Color.white;
        }
    }
}

public enum CellState
{
    Empty,
    HasTower,
    EnemyWay
}