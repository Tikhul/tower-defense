using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoadPlayerConfigCommand : LoadConfigsCommand<PlayerLibraryModel, PlayerConfig>
{
    protected override string GetPath()
    {
        return StaticName.PLAYER_PATH;
    }
}
