using strange.extensions.command.impl;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// ����������� ������� EnemyWay �������, �� ������� ���� ���� ������
/// </summary>
public class SetEnemyWayCommand : Command
{
    public override void Execute()
    {
        foreach(CellButton cell in injectionBinder.GetInstance<GameModel>().Board.CurrentCellList)
        {
            foreach (string index in injectionBinder.GetInstance<LevelsPipelineModel>().CurrentLevel.EnemyWay.Indexes)
            {
                if(index.Equals(cell.CellInt.ToString() + cell.CellChar.ToString()))
                {
                    cell.State = CellState.EnemyWay;
                }
            }
        }
        injectionBinder.GetInstance<OnEnemyDrawnSignal>().Dispatch();
    }
}
