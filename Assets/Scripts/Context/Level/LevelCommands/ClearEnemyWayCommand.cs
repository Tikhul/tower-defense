using strange.extensions.command.impl;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClearEnemyWayCommand : Command
{
    public override void Execute()
    {
        foreach (CellButton cell in injectionBinder.GetInstance<GameModel>().Board.CurrentCellList)
        {
            cell.State = CellState.Empty;
        }
    }
}
