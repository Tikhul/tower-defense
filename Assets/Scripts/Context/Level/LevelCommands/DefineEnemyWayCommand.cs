using context.level;
using strange.extensions.command.impl;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Подстановка статуса EnemyWay клеткам, по которым идет путь врагов
/// </summary>
public class DefineEnemyWayCommand : Command
{
    private List<string> _indices => injectionBinder.GetInstance<LevelsPipelineModel>().CurrentLevel.EnemyWay.Config.Indexes;
    public override void Execute()
    {
        foreach(CellButtonView cell in injectionBinder.GetInstance<GameModel>().Board.CurrentCellList)
        {
            for (int i = 0; i< _indices.Count; i++)
            {
                var index = _indices[i];
                if (index.Equals(cell.CellInt.ToString() + cell.CellChar.ToString()))
                {
                    cell.State = CellState.EnemyWay;
                    cell.OrderIndex = i;
                }
            }
        }
        injectionBinder.GetInstance<OnEnemyWayDefinedSignal>().Dispatch();
    }
}
