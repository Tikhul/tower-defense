using System.Collections;
using System.Linq;
using context.level;
using context.ui;
using strange.extensions.mediation.impl;
using UnityEngine;

public class TowerMediator : Mediator
{
    [Inject] public TowerView View { get; set; }
    [Inject] public StartShootingSignal StartShootingSignal { get; set; }
    [Inject] public RestartLevelChosenSignal RestartLevelChosenSignal { get; set; }
    [Inject] public NextLevelChosenSignal NextLevelChosenSignal { get; set; }
    [Inject] public RenewTowerDataSignal RenewTowerDataSignal { get; set; }
    [Inject] public LevelsPipelineModel LevelsPipelineModel { get; set; }

    public override void OnRegister()
    {
        StartShootingSignal.AddListener(LaunchShootingHandler);
        RestartLevelChosenSignal.AddListener(ClearTowersHandler);
        NextLevelChosenSignal.AddListener(ClearTowersHandler);
        RenewTowerDataSignal.AddListener(RenewDataHandler);
    }
    
    public override void OnRemove()
    {
        RestartLevelChosenSignal.RemoveListener(ClearTowersHandler);
        NextLevelChosenSignal.RemoveListener(ClearTowersHandler);
        RenewTowerDataSignal.RemoveListener(RenewDataHandler);
    }
    
    private void LaunchShootingHandler()
    {
        if (View.IsShooting)
        {
            StartCoroutine(WaitForLaunchShooting());
        }
    }

    private IEnumerator WaitForLaunchShooting()
    {
        StartShootingSignal.RemoveListener(LaunchShootingHandler);
        TowerModel towerModel = LevelsPipelineModel.CurrentLevel.TowerData[View];
            
        for (int i = 0; i < towerModel.BulletsNumber; i++)
        {
            NearestEnemyFinder finder = new NearestEnemyFinder();
            if (View.EnemyViews.Any())
            {
                View.TowerShoot(View, towerModel, finder.GetNearestEnemy(towerModel, View));
                yield return new WaitForSeconds(towerModel.ShootDelay);
            }
            else
            {
                break;
            }
        }
        StartShootingSignal.AddListener(LaunchShootingHandler);
    }
    private void ClearTowersHandler()
    {
        View.RenewData();
        View.Hide();
    }

    private void RenewDataHandler()
    {
        View.RenewData();
    }

    private void RemoveEnemyHandler(EnemyView view)
    {
        View.DeleteEnemyView(view);
    }
}
