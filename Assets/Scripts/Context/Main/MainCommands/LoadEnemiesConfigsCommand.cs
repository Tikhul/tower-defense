using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoadEnemiesConfigsCommand : LoadConfigsCommand<EnemiesLibraryModel, EnemyConfig>
{
    protected override string GetPath()
    {
        return StaticName.ENEMIES_PATH;
    }
}
