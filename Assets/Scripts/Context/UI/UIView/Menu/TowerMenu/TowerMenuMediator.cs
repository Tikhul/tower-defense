using strange.extensions.mediation.impl;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerMenuMediator : Mediator
{
    [Inject] public TowerMenuView View { get; set; }
    [Inject] public TowerMenuCreatedSignal TowerMenuCreatedSignal { get; set; }
    [Inject] public HideMenuSignal HideMenuSignal { get; set; }
    [Inject] public TowerChosenSignal TowerChosenSignal { get; set; }
    public override void OnRegister()
    {
        TowerMenuCreatedSignal.AddListener(SetUpTowerButtonsHandler);
        HideMenuSignal.AddListener(ClearMenuHandler);
        View.OnTowerButtonCreated += TowerButtonChosenHandler;
    }

    public override void OnRemove()
    {
        TowerMenuCreatedSignal.RemoveListener(SetUpTowerButtonsHandler);
        HideMenuSignal.RemoveListener(ClearMenuHandler);
        View.OnTowerButtonCreated -= TowerButtonChosenHandler;
    }
    private void SetUpTowerButtonsHandler(List<TowerView> list)
    {
        View.SetUpTowerButtons(list);
        View.Show();
    }

    private void ClearMenuHandler()
    {
        View.Hide();
        View.ClearMenu();
    }

    private void TowerButtonChosenHandler(TowerButton button)
    {
        TowerChosenSignal.Dispatch(button);
    }
}
