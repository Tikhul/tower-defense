using context.level;
using context.ui;
using strange.extensions.command.impl;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Присвоение индексов клеткам поля
/// </summary>
public class FillCellListCommand : Command
{
    [Inject] public GameObject Button { get; set; }
    [Inject] public char Char { get; set; }
    [Inject] public int Int { get; set; }
    private GameModel GameModel => injectionBinder.GetInstance<GameModel>();
    public override void Execute()
    {
        CellView buttonSettings = Button.GetComponent<CellView>();
        buttonSettings.CellChar = Char;
        buttonSettings.CellInt = Int;
        GameModel.Board.CurrentCellList.Add(buttonSettings);
        GameModel.Board.AllCellList.Add(buttonSettings);
        injectionBinder.GetInstance<CellViewCreatedSignal>().Dispatch(buttonSettings);

        if (GameModel.Board.AllCellList.Count == GameModel.Board.Settings.RowNumber * GameModel.Board.Settings.RowNumber)
        {
            injectionBinder.GetInstance<PipelineStartSignal>().Dispatch();
        }
    }
}
