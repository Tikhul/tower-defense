using strange.extensions.command.impl;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// «апись выбранных башен в модель уровн€
/// </summary>
public class CreateTowerModelCommand : Command
{
    [Inject] public TowerButton TowerButton { get; set; }
    [Inject] public LevelsPipelineModel LevelsPipelineModel { get; set; }
    public override void Execute()
    {
        TowerModel newTower = new TowerModel(TowerButton.TowerView.TowerSO);
        LevelsPipelineModel.CurrentLevel.TowerModels.Add(newTower);
    }
}
