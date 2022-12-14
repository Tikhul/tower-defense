using UnityEngine;
using UnityEngine.UI;
using TMPro;
using strange.extensions.mediation.impl;
using System;

/// <summary>
/// ?????? ??? ????
/// </summary>
public class CellButtonView : View
{
    private int _cellInt;
    private char _cellChar;
    public CellState State { get; set; } = CellState.Empty;
    public int OrderIndex { get; set; }
    [SerializeField] private TMP_Text _buttonText;
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
        ButtonElement.interactable = false;
    }
    public void UnblockButton()
    {
        if (!State.Equals(CellState.EnemyWay))
        {
            ButtonElement.interactable = true;
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
            ButtonElement.interactable = false;
            GetComponent<Image>().color = Color.blue;
        }
        else
        {
            ButtonElement.interactable = true;
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