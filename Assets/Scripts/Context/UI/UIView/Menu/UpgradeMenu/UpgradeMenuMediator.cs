using context.ui;
using strange.extensions.mediation.impl;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UpgradeMenuMediator : Mediator
{
    private List<UpgradeButtonView> _upgradeButtons = new List<UpgradeButtonView>();
    private bool _subscribedToUpdate = false;
    [Inject] public UpgradeMenuView View { get; set; }
    [Inject] public UpgradeMenuCreatedSignal UpgradeMenuCreatedSignal { get; set; }
    [Inject] public HideMenuSignal HideMenuSignal { get; set; }
    [Inject] public UpgradeChosenSignal UpgradeChosenSignal { get; set; }
    [Inject] public ShowTowerDataSignal ShowTowerDataSignal { get; set; }
    [Inject] public TowerUpgradedSignal TowerUpgradedSignal { get; set; }

    public override void OnRegister()
    {
        ShowTowerDataSignal.AddListener(ShowTowerDataHandler);
        UpgradeMenuCreatedSignal.AddListener(SetUpUpgradeButtonViewsHandler);
        HideMenuSignal.AddListener(ClearMenuHandler);
        View.OnUpgradeButtonViewCreated += GetUpgrades;
        TowerUpgradedSignal.AddListener(SubscribeToUpgradeHandler);
    }
    public override void OnRemove()
    {
        ShowTowerDataSignal.RemoveListener(ShowTowerDataHandler);
        UpgradeMenuCreatedSignal.RemoveListener(SetUpUpgradeButtonViewsHandler);
        HideMenuSignal.RemoveListener(ClearMenuHandler);
        TowerUpgradedSignal.RemoveListener(SubscribeToUpgradeHandler);
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
        SubscribeToUpgradeHandler();
    }
    private void GetUpgrades(List<UpgradeButtonView> _list)
    {
        _upgradeButtons.Clear();
        _upgradeButtons.AddRange(_list);
        View.OnUpgradeButtonViewCreated -= GetUpgrades;
        SubscribeToUpgradeHandler();
      //  Debug.Log("GetUpgrades");
    }
    private void SubscribeToUpgradeHandler()
    {
       // Debug.Log("SubscribeToUpgradeHandler");
       // Debug.Log(_subscribedToUpdate);
        //if (!_subscribedToUpdate)
        //{
            foreach (var button in _upgradeButtons)
            {
                button.OnUpgradeButtonViewClick += UpgradeTowerHandler;
            }
        //}
        _subscribedToUpdate = true;
    }
    private void UnsubscribeToUpgradeHandler()
    {
      //  Debug.Log("UnsubscribeToUpgradeHandler");
        foreach (var button in _upgradeButtons)
        {
            Debug.Log("Отписка");
            button.OnUpgradeButtonViewClick -= UpgradeTowerHandler;
        }
        _subscribedToUpdate = false;
    }
    private void UpgradeTowerHandler(UpgradeButtonView button)
    {
        Debug.Log("UpgradeTowerHandler");
        UnsubscribeToUpgradeHandler();
        UpgradeChosenSignal.Dispatch(button);
    }
    private void ShowTowerDataHandler(TowerModel tower)
    {
        View.ShowTowerData(tower);
    }
}
