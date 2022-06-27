using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyWayModel
{
    public EnemyWaySO Config { get; private set; }

    public EnemyWayModel(EnemyWaySO config)
    {
        Config = config;
    }
}
