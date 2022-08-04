using context.ui;
using strange.extensions.command.impl;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

/// <summary>
/// Создание меню улучшений для башни
/// </summary>
public class CreateUpgradeMenuCommand : Command
{
    [Inject] public CellView CellView { get; set; }

    public override void Execute()
    {
        TowerView activeView = CellView.Towers.TowerViews.FirstOrDefault(c => c.gameObject.activeInHierarchy);

        List<UpgradeConfig> _list = new List<UpgradeConfig>();

        foreach (var upgrade in activeView.TowerConfig.Upgrades)
        {
            _list.Add(upgrade);
        }
        
        injectionBinder.GetInstance<UpgradeMenuCreatedSignal>().Dispatch(_list, activeView);
    }
}
