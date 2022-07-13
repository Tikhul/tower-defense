using context.ui;
using strange.extensions.command.impl;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UpgradeTowerCommand : Command
{
    [Inject] public UpgradeButtonView UpgradeButtonView { get; set; }
    public override void Execute()
    { 
        injectionBinder.GetInstance<LevelsPipelineModel>().CurrentLevel.TowerData[UpgradeButtonView.ActiveView]
            .Upgrade(UpgradeButtonView.UpgradeConfig);
        injectionBinder.GetInstance<ShowTowerDataSignal>().Dispatch(
            injectionBinder.GetInstance<LevelsPipelineModel>().CurrentLevel.TowerData[UpgradeButtonView.ActiveView]);
        Debug.Log("UpgradeTowerCommand");
    }
}
