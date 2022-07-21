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
    public void FillWayPoints(List<Vector3> _receivedTransforms)
    {
        Debug.Log("FillWayPoints");
        Path.wps.AddRange(_receivedTransforms);
        transform.DOPath(Path.wps.ToArray(), 6f);
        Debug.Log(Path.wps.Count);
    }
    public void ClearEnemies()
    {
        transform.DOKill();
        Destroy(gameObject);
    }
}
