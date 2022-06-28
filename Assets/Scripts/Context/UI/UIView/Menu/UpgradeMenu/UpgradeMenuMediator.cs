using strange.extensions.mediation.impl;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UpgradeMenuMediator : Mediator
{
    [Inject] public UpgradeMenuView View { get; set; }
    [Inject] public UpgradeMenuCreatedSignal UpgradeMenuCreatedSignal { get; set; }
    [Inject] public HideMenuSignal HideMenuSignal { get; set; }
    [Inject] public UpgradeChosenSignal UpgradeChosenSignal { get; set; }
    [Inject] public ShowTowerDataSignal ShowTowerDataSignal { get; set; }

    public override void OnRegister()
    {
        ShowTowerDataSignal.AddListener(ShowTowerDataHandler);
        UpgradeMenuCreatedSignal.AddListener(SetUpUpgradeButtonsHandler);
        HideMenuSignal.AddListener(ClearMenuHandler);
        View.OnUpgradeButtonCreated += SubscribeToUpgradeHandler;
    }
    public override void OnRemove()
    {
        ShowTowerDataSignal.RemoveListener(ShowTowerDataHandler);
        UpgradeMenuCreatedSignal.RemoveListener(SetUpUpgradeButtonsHandler);
        HideMenuSignal.RemoveListener(ClearMenuHandler);
        View.OnUpgradeButtonCreated -= SubscribeToUpgradeHandler;
    }
    private void SetUpUpgradeButtonsHandler(List<UpgradeSO> _list, TowerView activeView)
    {
        View.SetUpUpgradeButtons(_list, activeView);
        View.Show();
    }

    private void ClearMenuHandler()
    {
        View.Hide();
        View.ClearMenu();
    }
    private void SubscribeToUpgradeHandler(UpgradeButton button) 
    {
        button.OnUpgradeButtonClick += UpgradeTowerHandler;
    }
    private void UpgradeTowerHandler(UpgradeButton button)
    {
        UpgradeChosenSignal.Dispatch(button);
    }
    private void ShowTowerDataHandler(TowerModel tower)
    {
        View.ShowTowerData(tower);
    }
}
