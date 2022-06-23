using strange.extensions.mediation.impl;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuMediator : Mediator
{
    [Inject] public MenuView View { get; set; }
    [Inject] public CellButtonCreatedSignal CellButtonCreatedSignal { get; set; }

    public override void OnRegister()
    {
        CellButtonCreatedSignal.AddListener(SubscribeToCells);
    }

    public override void OnRemove()
    {
        CellButtonCreatedSignal.RemoveListener(SubscribeToCells);
    }
    private void SubscribeToCells(CellButton cell)
    {
        cell.OnCellButtonClick += ShowMenu;
    }

    private void ShowMenu(CellState state)
    {
        View.Show();
        Debug.Log("ShowMenu");
    }
}
