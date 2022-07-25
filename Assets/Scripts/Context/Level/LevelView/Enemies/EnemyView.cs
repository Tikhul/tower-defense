using DG.Tweening;
using strange.extensions.mediation.impl;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyView : BaseView
{
    [SerializeField] private EnemyConfig _config;
    [SerializeField] private DOTweenPath _path;
    public bool IsLast { get; set; }
    public EnemyConfig Config => _config;
    public DOTweenPath Path => _path;
    public event Action OnLastEnemy = delegate { };
    public event Action<int> OnEnemyWayCompleted = delegate { };
    public void FillWayPoints(List<Vector3> _receivedTransforms)
    {
        var _duration = _receivedTransforms.Count / _config.Speed;
        Path.wps.AddRange(_receivedTransforms);
        transform.DOPath(Path.wps.ToArray(), _duration).OnComplete(PerformAfterPath);
    }
    private void PerformAfterPath()
    {
        if (IsLast)
        {
            OnLastEnemy.Invoke();
        }
        IsLast = false;
        OnEnemyWayCompleted?.Invoke(Config.Damage);
        ClearEnemies();
    }
    public void ClearEnemies()
    {
        transform.DOKill();
        Destroy(gameObject);
    }
}
