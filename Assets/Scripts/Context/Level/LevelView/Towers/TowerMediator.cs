using context.level;
using context.ui;
using strange.extensions.mediation.impl;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class TowerMediator : Mediator
{
    [Inject] public TowerView View { get; set; }
    [Inject] public LevelsPipelineModel LevelsPipelineModel { get; set; }
    [Inject] public ReadyToShootSignal ReadyToShootSignal { get; set; }
    [Inject] public PrepareForShootSignal PrepareForShootSignal { get; set; }

    public override void OnRegister()
    {
        ReadyToShootSignal.AddListener(LaunchShootingHandler);
        View.OnBulletShot += PrepareAnotherShootHandler;
    }
    public override void OnRemove()
    {
        ReadyToShootSignal.RemoveListener(LaunchShootingHandler);
        View.OnBulletShot -= PrepareAnotherShootHandler;
    }
    private void LaunchShootingHandler(Vector3 nearestEnemy, TowerModel towerModel)
    {
        if (View.IsShooting)
        {
            View.LaunchShooting(nearestEnemy, towerModel);
  //          Debug.Log("LaunchShootingHandler");
        } 
    }
    private void PrepareAnotherShootHandler(TowerModel _towerModel)
    {
        PrepareForShootSignal.Dispatch(_towerModel, View);
    }
}
