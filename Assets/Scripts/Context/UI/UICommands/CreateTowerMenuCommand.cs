using context.ui;
using strange.extensions.command.impl;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Создание меню из башен (для пустых клеток)
/// </summary>
public class CreateTowerMenuCommand : Command
{
    [Inject] public CellButtonView CellButtonView { get; set; }

    public override void Execute()
    {
        List<TowerView> _list = new List<TowerView>();

        foreach (var tower in CellButtonView.Towers.TowerViews)
        {
            _list.Add(tower);
        }

        injectionBinder.GetInstance<TowerMenuCreatedSignal>().Dispatch(_list);
    }
}
