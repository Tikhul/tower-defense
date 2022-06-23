using strange.extensions.mediation.impl;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuMediator : Mediator
{
    private List<CellButton> _cells = new List<CellButton>();
    [Inject] public MenuView View { get; set; }
    [Inject] public CellButtonCreatedSignal CellButtonCreatedSignal { get; set; }
    [Inject] public BlockBoardSignal BlockBoardSignal { get; set; }
    [Inject] public UnblockBoardSignal UnblockBoardSignal { get; set; }
    [Inject] public NextLevelChosenSignal NextLevelChosenSignal { get; set; }

    public override void OnRegister()
    {
        CellButtonCreatedSignal.AddListener(SubscribeToCells);
        NextLevelChosenSignal.AddListener(Unsubscribe);
    }

    public override void OnRemove()
    {
        CellButtonCreatedSignal.RemoveListener(SubscribeToCells);
        
    }
    private void SubscribeToCells(CellButton cell)
    {
        _cells.Add(cell);
        cell.OnCellButtonClick += ShowMenu;
    }

    private void ShowMenu(CellState state)
    {
        BlockBoardSignal.Dispatch();
        View.Show();
        View.OnCloseMenu += HideMenu;
        foreach (var cell in _cells) cell.OnCellButtonClick += ShowMenu;
        Debug.Log("ShowMenu");
    }

    private void HideMenu()
    {
        UnblockBoardSignal.Dispatch();
        View.Hide();
        View.OnCloseMenu -= HideMenu;
        foreach (var cell in _cells) cell.OnCellButtonClick -= ShowMenu;
        Debug.Log("HideMenu");
    }

    private void Unsubscribe()
    {
        foreach (var cell in _cells) cell.OnCellButtonClick -= ShowMenu;
    }
}
