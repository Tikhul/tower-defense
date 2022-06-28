using strange.extensions.mediation.impl;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UpgradeMenuMediator : Mediator
{
    private List<UpgradeButton> _upgradeButtons = new List<UpgradeButton>();
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
        UpgradeMenuCreatedSignal.AddListener(SetUpUpgradeButtonsHandler);
        HideMenuSignal.AddListener(ClearMenuHandler);
        View.OnUpgradeButtonCreated += GetUpgrades;
        TowerUpgradedSignal.AddListener(SubscribeToUpgradeHandler);
    }
    public override void OnRemove()
    {
        ShowTowerDataSignal.RemoveListener(ShowTowerDataHandler);
        UpgradeMenuCreatedSignal.RemoveListener(SetUpUpgradeButtonsHandler);
        HideMenuSignal.RemoveListener(ClearMenuHandler);
        TowerUpgradedSignal.RemoveListener(SubscribeToUpgradeHandler);
        UnsubscribeToUpgradeHandler();
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
        SubscribeToUpgradeHandler();
    }
    private void GetUpgrades(List<UpgradeButton> _list)
    {
        _upgradeButtons.Clear();
        _upgradeButtons.AddRange(_list);
        View.OnUpgradeButtonCreated -= GetUpgrades;
        SubscribeToUpgradeHandler();
        Debug.Log("GetUpgrades");
    }
    private void SubscribeToUpgradeHandler()
    {
        Debug.Log("ResubscribeToUpgradeHandler");
        
        if (!_subscribedToUpdate)
        {
            foreach (var button in _upgradeButtons)
            {
                Debug.Log("Подписка");
                button.OnUpgradeButtonClick += UpgradeTowerHandler;
            }
            _subscribedToUpdate = true;
        }
    }
    private void UnsubscribeToUpgradeHandler()
    {
        Debug.Log("UnsubscribeToUpgradeHandler");
        foreach (var button in _upgradeButtons)
        {
            button.OnUpgradeButtonClick -= UpgradeTowerHandler;
        }
        _subscribedToUpdate = false;
    }
    private void UpgradeTowerHandler(UpgradeButton button)
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
