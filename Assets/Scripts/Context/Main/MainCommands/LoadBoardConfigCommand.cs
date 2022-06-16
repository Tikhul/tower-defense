using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoadBoardConfigCommand : LoadConfigsCommand<BoardLibraryModel, BoardSO>
{
    protected override string GetPath()
    {
        return StaticName.BOARD_PATH;
    }

}
