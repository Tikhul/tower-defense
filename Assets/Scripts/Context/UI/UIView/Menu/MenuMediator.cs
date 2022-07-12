using context.ui;
using strange.extensions.mediation.impl;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuMediator : Mediator
{
    private List<CellButton> _cells = new List<CellButton>();
    
    private bool _subscribedToCells = false;
    
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
        TowerChosenSignal.AddListener(TowerButtonClickedHandler);
    }

    public override void OnRemove()
    {
        CellButtonCreatedSignal.RemoveListener(SubscribeToCells);
        TowerChosenSignal.RemoveListener(TowerButtonClickedHandler);

    }
    private void SubscribeToCells(CellButton cell)
    {
        _cells.Add(cell);
        cell.OnCellButtonClick += ShowMenu;
        _subscribedToCells = true;
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
            Debug.Log("ShowMenu");
    }
    private void TowerButtonClickedHandler(TowerButton button)
    {
        HideMenu();
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
        HideMenuSignal.Dispatch();
        Debug.Log("HideMenu");
    }
}
