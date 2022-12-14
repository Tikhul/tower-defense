using context.ui;
using strange.extensions.command.impl;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

/// <summary>
/// ???????? ???? ????????? ??? ?????
/// </summary>
public class CreateUpgradeMenuCommand : Command
{
    [Inject] public CellButtonView CellButtonView { get; set; }

    public override void Execute()
    {
        TowerView activeView = CellButtonView.Towers.TowerViews.FirstOrDefault(c => c.gameObject.activeInHierarchy);

        List<UpgradeConfig> _list = new List<UpgradeConfig>();

        foreach (var upgrade in activeView.TowerConfig.Upgrades)
        {
            _list.Add(upgrade);
        }
        
        injectionBinder.GetInstance<UpgradeMenuCreatedSignal>().Dispatch(_list, activeView);
    }
}
