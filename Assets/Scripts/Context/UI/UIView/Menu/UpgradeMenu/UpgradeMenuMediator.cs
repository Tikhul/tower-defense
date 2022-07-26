using context.ui;
using strange.extensions.mediation.impl;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UpgradeMenuMediator : Mediator
{
    private TowerModel _towerModel;
    private TowerView _towerView;
    [Inject] public UpgradeMenuView View { get; set; }
    [Inject] public UpgradeMenuCreatedSignal UpgradeMenuCreatedSignal { get; set; }
    [Inject] public HideMenuSignal HideMenuSignal { get; set; }
    [Inject] public ShowTowerDataSignal ShowTowerDataSignal { get; set; }
    [Inject] public PrepareForShootSignal PrepareForShootSignal { get; set; }
    [Inject] public UpgradeChosenSignal UpgradeChosenSignal { get; set; }

    public override void OnRegister()
    {
        ShowTowerDataSignal.AddListener(ShowTowerDataHandler);
        UpgradeMenuCreatedSignal.AddListener(SetUpUpgradeButtonViewsHandler);
        HideMenuSignal.AddListener(ClearMenuHandler);
        View.OnShootButtonClicked += PrepareForShootHandler;
        UpgradeChosenSignal.AddListener(UpgradeHandler);
    }
    public override void OnRemove()
    {
        ShowTowerDataSignal.RemoveListener(ShowTowerDataHandler);
        UpgradeMenuCreatedSignal.RemoveListener(SetUpUpgradeButtonViewsHandler);
        HideMenuSignal.RemoveListener(ClearMenuHandler);
        View.OnShootButtonClicked -= PrepareForShootHandler;
        UpgradeChosenSignal.RemoveListener(UpgradeHandler);
    }
    private void SetUpUpgradeButtonViewsHandler(List<UpgradeConfig> _list, TowerView activeView)
    {
        _towerView = activeView;
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
        _towerModel = tower;
        View.ShowTowerData(tower);
    }
    private void PrepareForShootHandler()
    {
        _towerView.IsShooting = true;
        PrepareForShootSignal.Dispatch(_towerModel);
    }
    private void UpgradeHandler(UpgradeButtonView _view)
    {
        _towerView.UpgradeRadius(_view.UpgradeConfig.ShootRadius);
    }
}
