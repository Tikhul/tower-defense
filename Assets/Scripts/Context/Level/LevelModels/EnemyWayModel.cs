using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyWayModel
{
    public EnemyWayConfig Config { get; private set; }

    public EnemyWayModel(EnemyWayConfig config)
    {
        Config = config;
    }
}
