using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoadTowersConfigsCommand : LoadConfigsCommand<TowersLibraryModel, TowerConfig>
{
    protected override string GetPath()
    {
        return StaticName.TOWERS_PATH;
    }
}

