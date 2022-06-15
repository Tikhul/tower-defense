using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoadTowersConfigsCommand : LoadConfigsCommand<TowersLibraryModel, TowerSO>
{
    protected override string GetPath()
    {
        return StaticName.TOWERS_PATH;
    }
}

