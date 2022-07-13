using context.ui;
using strange.extensions.mediation.impl;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UpgradeButtonMediator : Mediator
{
    [Inject] public UpgradeButtonView View { get; set; }
    [Inject] public UpgradeChosenSignal UpgradeChosenSignal { get; set; }
    [Inject] public ShowTowerDataSignal ShowTowerDataSignal { get; set; }
    public override void OnRegister()
    {
        View.OnUpgradeButtonViewClick += UpgradeTowerHandler;
    }
    public override void OnRemove()
    {
        View.OnUpgradeButtonViewClick -= UpgradeTowerHandler;
    }
    private void UpgradeTowerHandler()
    {
        Debug.Log("UpgradeTowerHandler");
        UpgradeChosenSignal.Dispatch(View);
    }
}
