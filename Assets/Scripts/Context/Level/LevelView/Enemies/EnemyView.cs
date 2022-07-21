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
        for(int i=0; i<_receivedTransforms.Count; i++)
        {
            Path.wps.Add(_receivedTransforms[i]);
        }
        transform.DOPath(Path.wps.ToArray(), 5f);
    }
    public void ClearEnemies()
    {
        Destroy(gameObject);
    }
}
