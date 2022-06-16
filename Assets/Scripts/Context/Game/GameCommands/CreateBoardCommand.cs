using strange.extensions.command.impl;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreateBoardCommand : Command
{
    [Inject] public BoardLibraryCreatedSignal BoardLibraryCreatedSignal { get; set; }
    [Inject] public BoardCreatedSignal BoardCreatedSignal { get; set; }
    public override void Execute()
    {
        BoardLibraryCreatedSignal.AddListener(CreateBoard);
    }

    private void CreateBoard(BoardSO settings)
    {
        var board = new BoardModel(settings);
        BoardCreatedSignal.Dispatch(board);
        BoardLibraryCreatedSignal.RemoveListener(CreateBoard);
        Debug.Log("CreateBoard");
    }
}
