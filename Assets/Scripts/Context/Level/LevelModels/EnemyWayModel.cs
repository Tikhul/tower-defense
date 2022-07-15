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
    public List<Vector3> GetEnemyWayTransforms(List<CellButtonView> enemyWayButtons)
    {
        List<Vector3> _temp = new List<Vector3>();
        for(int i=0; i< enemyWayButtons.Count; i++)
        {
            _temp.Add(enemyWayButtons[i].Enemies.transform.position);
        }
        return _temp;
    }
}
