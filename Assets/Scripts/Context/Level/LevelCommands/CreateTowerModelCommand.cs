using context.ui;
using strange.extensions.command.impl;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Запись выбранных башен в модель уровня (словарь Кнопка-модель)
/// </summary>
public class CreateTowerModelCommand : Command
{
    [Inject] public TowerButtonView TowerButtonView { get; set; }
    public override void Execute()
    {
        Debug.Log("CreateTowerModelCommand");
        TowerModel newTower = new TowerModel(TowerButtonView.TowerView.TowerConfig);
        injectionBinder.GetInstance<LevelsPipelineModel>().CurrentLevel.TowerData.Add(TowerButtonView.TowerView, newTower);
        Debug.Log(TowerButtonView.TowerView.TowerConfig.name);
        injectionBinder.GetInstance<ShowTowerDataSignal>().Dispatch(newTower);
    }
}
