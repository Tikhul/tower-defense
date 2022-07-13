using context.ui;
using strange.extensions.command.impl;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UpgradeTowerCommand : Command
{
    [Inject] public UpgradeButtonView UpgradeButtonView { get; set; }
    private TowerModel _currentTower => injectionBinder.GetInstance<LevelsPipelineModel>().CurrentLevel.TowerData[UpgradeButtonView.ActiveView];
    public override void Execute()
    { 
        _currentTower.Damage += UpgradeButtonView.UpgradeConfig.Damage;
        _currentTower.ShootFrequency += UpgradeButtonView.UpgradeConfig.ShootFrequency;
        _currentTower.ShootRadius += UpgradeButtonView.UpgradeConfig.ShootRadius;
        injectionBinder.GetInstance<LevelsPipelineModel>().CurrentLevel.TowerData[UpgradeButtonView.ActiveView] = _currentTower;
        injectionBinder.GetInstance<ShowTowerDataSignal>().Dispatch(_currentTower);
        Debug.Log("UpgradeTowerCommand");
    }
}
