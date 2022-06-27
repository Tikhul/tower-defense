using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UpgradeModel : IUpgradeModel
{
    public UpgradeSO Config { get; private set; }

    public UpgradeModel(UpgradeSO config)
    {
        Config = config;
    }
}

public interface IUpgradeModel
{
    UpgradeSO Config { get; }
}
