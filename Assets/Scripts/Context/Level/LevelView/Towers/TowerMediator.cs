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
        View.OnBulletShot += PrepareAnotherShootHandler;
    }
    public override void OnRemove()
    {
        CollectEnemiesTransformsSignal.RemoveListener(CollectEnemyTransforms);
        View.OnBulletShot -= PrepareAnotherShootHandler;
    }
    private void CollectEnemyTransforms(Vector3 _enemyTransform, TowerModel _tower)
    {
        if (View.IsShooting && View.ShootsNumber <= _tower.BulletsNumber)
        {
            Debug.Log("CollectEnemyTransforms");
            _enemyTransforms.Add(_enemyTransform);
            if (_enemyTransforms.Count ==
                LevelsPipelineModel.CurrentLevel.LevelWaves.CurrentWave.EnemiesOnScene.Count)
            {
                LaunchShootingHandler(_enemyTransforms.FindAll(x => !x.Equals(Vector3.zero)), _tower);
                _enemyTransforms.Clear();
            }
        }
    }
    private void LaunchShootingHandler(List<Vector3> _receivedTransforms, TowerModel _towerModel)
    {
        Debug.Log("TurnTowerHandler");
        View.LaunchShooting(_receivedTransforms, _towerModel);
    }
    private void PrepareAnotherShootHandler(TowerModel _towerModel)
    {
        
    }
}
