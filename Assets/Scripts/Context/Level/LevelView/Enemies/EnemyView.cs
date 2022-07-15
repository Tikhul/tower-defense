using DG.Tweening;
using strange.extensions.mediation.impl;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyView : View
{
    [SerializeField] private EnemyConfig _config;
    [SerializeField] private DOTweenPath _path;
    public EnemyConfig Config => _config;
    public DOTweenPath Path => _path;
    public void FillWayPoints(EnemyWayModel enemyWay)
    {
        Debug.Log("FillWayPoints");
    }
    public void ClearEnemies()
    {
        Destroy(gameObject);
    }
}
