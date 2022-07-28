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

    public override void OnRegister()
    {
        View.OnBulletShot += PrepareAnotherShootHandler;
    }
    public override void OnRemove()
    {
        View.OnBulletShot -= PrepareAnotherShootHandler;
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
