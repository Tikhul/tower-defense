using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerModel
{
    public TowerSO Config { get; private set; }
    public Dictionary<UpgradeButton, UpgradeModel> UpgradeModelsDict = new Dictionary<UpgradeButton, UpgradeModel>();

    public TowerModel(TowerSO config)
    {
        Config = config;
    }
}
