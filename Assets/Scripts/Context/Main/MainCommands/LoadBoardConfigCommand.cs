using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoadBoardConfigCommand : LoadConfigsCommand<BoardLibraryModel, BoardSO>
{
    [Inject] public CreateBoardLibrarySignal CreateBoardLibrarySignal { get; set; }
    [Inject] public BoardLibraryCreatedSignal BoardLibraryCreatedSignal { get; set; }
    protected override string GetPath()
    {
        CreateBoardLibrarySignal.AddListener(PassData);
        return StaticName.BOARD_PATH;
    }

    public override void PassData()
    {
        var board = new BoardLibraryModel();
        BoardLibraryCreatedSignal.Dispatch(board.GetLibraryDataById("board"));
        CreateBoardLibrarySignal.RemoveListener(PassData);
        Debug.Log("PassBoardData");
    }
}
