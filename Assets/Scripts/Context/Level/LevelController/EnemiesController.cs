using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class AbstractEnemiesGenerator<Dict>
{
    public abstract EnemyModel GenerateEnemy();
}

public class EnemyGenerator : AbstractEnemiesGenerator<Dictionary<EnemyModel, int>>
{
    public override EnemyModel GenerateEnemy()
    {
        return null;
    }
}