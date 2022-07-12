using context.ui;
using strange.extensions.context.api;
using strange.extensions.mediation.impl;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerMenuMediator : Mediator
{
    private bool _subscribedToTowers = false;
    private List<TowerButtonView> _towers = new List<TowerButtonView>();
    [Inject] public TowerMenuView View { get; set; }
    [Inject] public TowerMenuCreatedSignal TowerMenuCreatedSignal { get; set; }
    [Inject] public HideMenuSignal HideMenuSignal { get; set; }
    [Inject] public TowerChosenSignal TowerChosenSignal { get; set; }
    [Inject] public TowerBoughtSignal TowerBoughtSignal { get; set; }

    public override void OnRegister()
    {
        TowerMenuCreatedSignal.AddListener(SetUpTowerButtonsHandler);
        HideMenuSignal.AddListener(ClearMenuHandler);
        TowerBoughtSignal.AddListener(ActivateTowerHandler);
        View.OnTowerButtonCreated += SubscribeToTowers;
    }
    public override void OnRemove()
    {
        TowerMenuCreatedSignal.RemoveListener(SetUpTowerButtonsHandler);
        HideMenuSignal.RemoveListener(ClearMenuHandler);
        View.OnTowerButtonCreated -= SubscribeToTowers;
        TowerBoughtSignal.RemoveListener(ActivateTowerHandler);
    }

    private void SubscribeToTowers(TowerButtonView button)
    {
        _towers.Add(button);
        button.OnTowerButtonClick += TowerButtonChosenHandler;
        _subscribedToTowers = true;
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
        if (!_subscribedToTowers)
        {
            foreach (var tower in _towers)
            {
                tower.OnTowerButtonClick += TowerButtonChosenHandler;
            }
        }
    }
    private void TowerButtonChosenHandler(TowerButtonView button)
    {
        Debug.Log("TowerButtonChosenHandler");
        TowerChosenSignal.Dispatch(button);
        foreach (var tower in _towers)
        {
            tower.OnTowerButtonClick -= TowerButtonChosenHandler;
            _subscribedToTowers = false;
        }
    }
    private void ActivateTowerHandler(TowerButtonView button)
    {
        button.ActivateTower();
    }
}
