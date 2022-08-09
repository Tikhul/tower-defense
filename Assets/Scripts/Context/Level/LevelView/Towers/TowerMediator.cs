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
    [Inject] public RestartLevelChosenSignal RestartLevelChosenSignal { get; set; }
    [Inject] public NextLevelChosenSignal NextLevelChosenSignal { get; set; }

    public override void OnRegister()
    {
        ReadyToShootSignal.AddListener(LaunchShootingHandler);
        View.OnBulletShot += PrepareAnotherShootHandler;
        RestartLevelChosenSignal.AddListener(ClearTowersHandler);
        NextLevelChosenSignal.AddListener(ClearTowersHandler);
    }
    public override void OnRemove()
    {
        ReadyToShootSignal.RemoveListener(LaunchShootingHandler);
        View.OnBulletShot -= PrepareAnotherShootHandler;
        RestartLevelChosenSignal.RemoveListener(ClearTowersHandler);
        NextLevelChosenSignal.RemoveListener(ClearTowersHandler);
    }
    private void LaunchShootingHandler(Vector3 nearestEnemy, TowerModel towerModel)
    {
        if (View.IsShooting)
        {
            View.LaunchShooting(nearestEnemy, towerModel);
        }
    }
    private void PrepareAnotherShootHandler(TowerModel _towerModel)
    {
        PrepareForShootSignal.Dispatch(_towerModel, View);
    }
    private void ClearTowersHandler()
    {
        View.RenewData();
        View.Hide();
    }
}
