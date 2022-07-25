using context.level;
using context.ui;
using strange.extensions.command.impl;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UpgradeTowerCommand : Command
{
    [Inject] public UpgradeButtonView UpgradeButtonView { get; set; }
    private LevelsPipelineModel LevelsPipelineModel => injectionBinder.GetInstance<LevelsPipelineModel>();
    public override void Execute()
    {
        LevelsPipelineModel.CurrentLevel.TowerData[UpgradeButtonView.ActiveView]
            .Upgrade(UpgradeButtonView.UpgradeConfig);
        injectionBinder.GetInstance<ShowTowerDataSignal>().Dispatch(
            LevelsPipelineModel.CurrentLevel.TowerData[UpgradeButtonView.ActiveView]);
        Debug.Log("UpgradeTowerCommand");
    }
}
