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
    [Inject] public CellButton CellButton { get; set; }


    public override void Execute()
    {
        TowerView activeView = CellButton.Towers.TowerViews.FirstOrDefault(c => c.gameObject.activeInHierarchy);

        List<UpgradeModel> _list = new List<UpgradeModel>();

        foreach (var upgrade in activeView.TowerSO.Upgrades)
        {
            UpgradeModel u = new UpgradeModel(upgrade);
            _list.Add(u);
        }
        
        injectionBinder.GetInstance<UpgradeMenuCreatedSignal>().Dispatch(_list, activeView);
        Debug.Log("CreateUpgradeMenuCommand");
    }
}
