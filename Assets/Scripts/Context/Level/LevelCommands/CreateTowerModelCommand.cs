using strange.extensions.command.impl;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Запись выбранных башен в модель уровня (словарь Кнопка-модель)
/// </summary>
public class CreateTowerModelCommand : Command
{
    [Inject] public TowerButton TowerButton { get; set; }
    public override void Execute()
    {
        Debug.Log("CreateTowerModelCommand");
        TowerModel newTower = new TowerModel(TowerButton.TowerView.TowerConfig);
        Debug.Log(TowerButton.TowerView.TowerConfig.name);
        injectionBinder.GetInstance<ShowTowerDataSignal>().Dispatch(newTower);
    }
}
