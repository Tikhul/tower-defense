using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoadEnemiesWaysCommand : LoadConfigsCommand<EnemyWayLibraryModel, EnemyWaySO>
{
    protected override string GetPath()
    {
        return StaticName.ENEMIES_WAYS_PATH;
    }
}
   