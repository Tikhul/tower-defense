using context.level;
using context.ui;
using strange.extensions.mediation.impl;
using System.Collections.Generic;
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
    private void LaunchShootingHandler(List<Vector3> _receivedTransforms, TowerModel _towerModel)
    {
        if (View.IsShooting)
        {
            View.LaunchShooting(_receivedTransforms, _towerModel);
            Debug.Log("LaunchShootingHandler");
        } 
    }
    private void PrepareAnotherShootHandler(TowerModel _towerModel)
    {
        PrepareForShootSignal.Dispatch(_towerModel);
    }
}
