using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoadEnemiesConfigsCommand : LoadConfigsCommand<EnemySO>
{
    protected override string GetPath()
    {
        return StaticName.ENEMIES_PATH;
    }
}
