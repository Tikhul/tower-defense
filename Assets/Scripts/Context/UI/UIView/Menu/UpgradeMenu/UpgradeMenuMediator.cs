using context.ui;
using strange.extensions.mediation.impl;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UpgradeMenuMediator : Mediator
{
    [Inject] public UpgradeMenuView View { get; set; }
    [Inject] public UpgradeMenuCreatedSignal UpgradeMenuCreatedSignal { get; set; }
    [Inject] public HideMenuSignal HideMenuSignal { get; set; }
    [Inject] public ShowTowerDataSignal ShowTowerDataSignal { get; set; }

    public override void OnRegister()
    {
        ShowTowerDataSignal.AddListener(ShowTowerDataHandler);
        UpgradeMenuCreatedSignal.AddListener(SetUpUpgradeButtonViewsHandler);
        HideMenuSignal.AddListener(ClearMenuHandler);
    }
    public override void OnRemove()
    {
        ShowTowerDataSignal.RemoveListener(ShowTowerDataHandler);
        UpgradeMenuCreatedSignal.RemoveListener(SetUpUpgradeButtonViewsHandler);
        HideMenuSignal.RemoveListener(ClearMenuHandler);
    }
    private void SetUpUpgradeButtonViewsHandler(List<UpgradeConfig> _list, TowerView activeView)
    {
        View.SetUpUpgradeButtonViews(_list, activeView);
        View.Show();
    }
    private void ClearMenuHandler()
    {
        View.Hide();
        View.ClearMenu();
    }
    private void ShowTowerDataHandler(TowerModel tower)
    {
        View.ShowTowerData(tower);
    }
}
