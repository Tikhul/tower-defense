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
    private List<string> _indices => injectionBinder.GetInstance<LevelsPipelineModel>().CurrentLevel.EnemyWay.Config.Indices;
    public override void Execute()
    {
        foreach(CellView cell in injectionBinder.GetInstance<GameModel>().Board.CurrentCellList)
        {
            for (int i = 0; i< _indices.Count; i++)
            {
                var index = _indices[i];
                Debug.Log(cell.CellInt.ToString() + cell.CellChar.ToString());
                Debug.Log(index);
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
