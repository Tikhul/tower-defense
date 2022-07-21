using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyModel
{
    public EnemyConfig Config { get; private set; }
    public bool IsLast { get; set; }
    public EnemyModel(EnemyConfig config)
    {
        Config = config;
    }
}
