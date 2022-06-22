using strange.extensions.command.impl;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetEnemyWayCommand : Command
{
    public override void Execute()
    {
        foreach(CellButtonView cell in injectionBinder.GetInstance<GameModel>().Board.CurrentCellList)
        {
            foreach (string index in injectionBinder.GetInstance<LevelsPipelineModel>().CurrentLevel.EnemyWay.Indexes)
            {
                if(index.Contains(cell.CellChar.ToString()) && index.Contains(cell.CellInt.ToString()))
                {
                    cell.State = CellState.HasTower;
                }
            }
        }
        
    }
}
