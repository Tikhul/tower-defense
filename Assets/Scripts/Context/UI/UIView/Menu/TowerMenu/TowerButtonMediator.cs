using context.ui;
using strange.extensions.mediation.impl;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerButtonMediator : Mediator
{
    [Inject] public TowerButtonView View { get; set; }
    [Inject] public TowerChosenSignal TowerChosenSignal { get; set; }
    [Inject] public TowerBoughtSignal TowerBoughtSignal { get; set; }
    public override void OnRegister()
    {
        View.OnTowerButtonClick += TowerButtonChosenHandler;
        
    }
    public override void OnRemove()
    {
        TowerBoughtSignal.RemoveListener(ActivateTowerHandler);
    }
    private void TowerButtonChosenHandler()
    {
        TowerBoughtSignal.AddListener(ActivateTowerHandler);
        TowerChosenSignal.Dispatch(View);
        View.OnTowerButtonClick -= TowerButtonChosenHandler;
    }
    private void ActivateTowerHandler()
    {
        View.ActivateTower();
        TowerBoughtSignal.RemoveListener(ActivateTowerHandler);
    }
}
