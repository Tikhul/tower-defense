using context.ui;
using strange.extensions.command.impl;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// ???????? ???? ?? ????? (??? ?????? ??????)
/// </summary>
public class CreateTowerMenuCommand : Command
{
    [Inject] public CellView CellView { get; set; }

    public override void Execute()
    {
        List<TowerView> _list = new List<TowerView>();

        foreach (var tower in CellView.Towers.TowerViews)
        {
            _list.Add(tower);
        }

        injectionBinder.GetInstance<TowerMenuCreatedSignal>().Dispatch(_list);
    }
}
