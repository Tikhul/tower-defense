using strange.extensions.command.impl;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// ������ ��������� ����� � ������ ������ (������� ������-������)
/// </summary>
public class CreateTowerModelCommand : Command
{
    [Inject] public TowerButton TowerButton { get; set; }
    [Inject] public LevelsPipelineModel LevelsPipelineModel { get; set; }
    public override void Execute()
    {
        Debug.Log("CreateTowerModelCommand");
        TowerModel newTower = new TowerModel(TowerButton.TowerView.TowerSO);
        Debug.Log(TowerButton.TowerView.TowerSO.name);
        injectionBinder.GetInstance<ShowTowerDataSignal>().Dispatch(newTower);
    }
}
