using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyWayModel
{
    public EnemyWayConfig Config { get; }
    public List<Vector3> EnemyWayTransforms { get; }

    public EnemyWayModel(EnemyWayConfig config)
    {
        Config = config;
    }
    public List<Vector3> GetEnemyWayTransforms(List<CellView> enemyWayButtons)
    {
        List<Vector3> _temp = new List<Vector3>();
        foreach (var t in enemyWayButtons)
        {
            _temp.Add(t.Enemies.transform.position);
        }
        return _temp;
    }
}
