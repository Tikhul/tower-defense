using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class CellView : CellHover, IInteractable
{
    private Color _enemyColor = Color.blue;
    public int CellInt { get; set; }
    public char CellChar { get; set; }
    public int OrderIndex { get; set; }
    public CellState State { get; set; } = CellState.Empty;
    public event Action<TowerView> OnShoot;
    public event Action<CellView> OnUpgradeMenuOpen;
    public event Action<CellView> OnTowerMenuOpen;
    [SerializeField] private AllTowersView _towers;
    [SerializeField] private AllEnemiesView _enemies;
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
        Interactable = true;
    }
    
    public void TryOpenMenu()
    {
        if (State.Equals(CellState.Empty))
        {
            OnTowerMenuOpen?.Invoke(this);
        }
        else if (State.Equals(CellState.HasTower))
        {
            OnUpgradeMenuOpen?.Invoke(this);
        }
    }

    public void TryShoot()
    {
        if (State.Equals(CellState.HasTower))
        {
            OnShoot?.Invoke(Towers.TowerViews.FirstOrDefault(x => x.gameObject.activeInHierarchy));
        }
        Debug.Log("TryShoot");
    }

    public void DrawEnemyWay()
    {
        if (State.Equals(CellState.EnemyWay))
        {
            Interactable = false;
            MeshRenderer.material.color = _enemyColor;
        }
    }

    public void BlockCell()
    {
        Interactable = false;
    }

    public void UnblockCell()
    {
        if (!State.Equals(CellState.EnemyWay))
        {
            Interactable = true;
            ClearColor();
        }     
    }
}

public enum CellState
{
    Empty,
    HasTower,
    EnemyWay
}
