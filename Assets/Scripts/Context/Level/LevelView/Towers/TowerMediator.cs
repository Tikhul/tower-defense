using context.level;
using context.ui;
using strange.extensions.mediation.impl;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerMediator : Mediator
{
    private List<Vector3> _enemyTransforms = new List<Vector3>();
    [Inject] public TowerView View { get; set; }
    [Inject] public LevelsPipelineModel LevelsPipelineModel { get; set; }
    [Inject] public CollectEnemiesTransformsSignal CollectEnemiesTransformsSignal { get; set; }

    public override void OnRegister()
    {
        CollectEnemiesTransformsSignal.AddListener(CollectEnemyTransforms);
    }
    public override void OnRemove()
    {
        CollectEnemiesTransformsSignal.RemoveListener(CollectEnemyTransforms);
    }
    private void CollectEnemyTransforms(Vector3 _enemyTransform)
    {
        if (View.IsShooting)
        {
            _enemyTransforms.Add(_enemyTransform);
            if (_enemyTransforms.Count ==
                LevelsPipelineModel.CurrentLevel.LevelWaves.CurrentWave.EnemiesOnScene.Count)
            {
                TurnTowerHandler(_enemyTransforms);
                _enemyTransforms.Clear();
            }
        }
    }
    private void TurnTowerHandler(List<Vector3> _receivedTransforms)
    {
        if (View.IsShooting)
        {
            View.TurnTower(_receivedTransforms);
        }
    }
}
