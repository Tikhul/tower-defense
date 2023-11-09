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
    
    public void AddEnemyWayTransform(Vector3 transform) => EnemyWayTransforms.Add(transform);
    public void ClearEnemyWaysTransforms() => EnemyWayTransforms.Clear();
}
