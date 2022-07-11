using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoadBoardConfigCommand : LoadConfigsCommand<BoardLibraryModel, BoardConfig>
{
    protected override string GetPath()
    {
        return StaticName.BOARD_PATH;
    }

}
