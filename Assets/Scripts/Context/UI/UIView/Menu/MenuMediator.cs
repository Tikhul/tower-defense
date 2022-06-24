using strange.extensions.mediation.impl;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuMediator : Mediator
{
    private List<CellButton> _cells = new List<CellButton>();
    private List<TowerButton> _towers = new List<TowerButton>();
    private bool _subscribedToCells = false;
    private bool _subscribedToTowers = false;
    [Inject] public MenuView View { get; set; }
    [Inject] public CellButtonCreatedSignal CellButtonCreatedSignal { get; set; }
    [Inject] public BlockBoardSignal BlockBoardSignal { get; set; }
    [Inject] public UnblockBoardSignal UnblockBoardSignal { get; set; }
    [Inject] public NextLevelChosenSignal NextLevelChosenSignal { get; set; }
    [Inject] public CreateTowerMenuSignal CreateTowerMenuSignal { get; set; }
    [Inject] public CreateUpgradeMenuSignal CreateUpgradeMenuSignal { get; set; }
    [Inject] public HideMenuSignal HideMenuSignal { get; set; }
    [Inject] public TowerChosenSignal TowerChosenSignal { get; set; }

    public override void OnRegister()
    {
        CellButtonCreatedSignal.AddListener(SubscribeToCells);
        TowerChosenSignal.AddListener(SubscribeToTowerButtons);
    }

    public override void OnRemove()
    {
        CellButtonCreatedSignal.RemoveListener(SubscribeToCells);
        TowerChosenSignal.RemoveListener(SubscribeToTowerButtons);

    }
    private void SubscribeToCells(CellButton cell)
    {
        _cells.Add(cell);
        cell.OnCellButtonClick += ShowMenu;
        _subscribedToCells = true;
    }

    private void SubscribeToTowerButtons(TowerButton towerButton)
    {
        _towers.Add(towerButton);
         towerButton.OnTowerButtonClick += HideMenu;
        _subscribedToTowers = true;
    }

    private void ShowMenu(CellButton receivedCell)
    {
        BlockBoardSignal.Dispatch();

        if (receivedCell.State.Equals(CellState.Empty))
        {
            CreateTowerMenuSignal.Dispatch(receivedCell);
        }
        else if (receivedCell.State.Equals(CellState.HasTower))
        {
            CreateUpgradeMenuSignal.Dispatch(receivedCell);
        }

        View.Show();
        View.OnCloseMenu += HideMenu;

        foreach (var cell in _cells)
        {
            cell.OnCellButtonClick -= ShowMenu;
            _subscribedToCells = false;
        }

        if (!_subscribedToTowers)
        {
            foreach (var tower in _towers)
            {
                tower.OnTowerButtonClick += HideMenu;

            }
        }
            Debug.Log("ShowMenu");
    }

    private void HideMenu()
    {
        UnblockBoardSignal.Dispatch();
        View.Hide();
        View.OnCloseMenu -= HideMenu;
        if (!_subscribedToCells)
        {
            foreach (var cell in _cells)
            {
                cell.OnCellButtonClick += ShowMenu;
                _subscribedToCells = true;
            }
        }

        foreach (var tower in _towers)
        {
            tower.OnTowerButtonClick -= HideMenu;
            _subscribedToTowers = false;
        }
        HideMenuSignal.Dispatch();
        Debug.Log("HideMenu");
    }
}
