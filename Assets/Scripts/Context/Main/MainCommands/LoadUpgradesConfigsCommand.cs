using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoadUpgradesConfigsCommand : LoadConfigsCommand<UpgradesLibraryModel, UpgradeSO>
{
    protected override string GetPath()
    {
        return StaticName.UPGRADES_PATH;
    }
}

