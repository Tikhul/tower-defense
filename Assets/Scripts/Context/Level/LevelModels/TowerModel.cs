using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerModel
{
    public TowerSO Config { get; private set; }

    public TowerModel(TowerSO config)
    {
        Config = config;
    }
}
