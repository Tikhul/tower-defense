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
    [Inject] public EnemyDestroyedSignal EnemyDestroyedSignal { get; set; }
    
    public override void OnRegister()
    {
        StartShootingSignal.AddListener(LaunchShootingHandler);
        RestartLevelChosenSignal.AddListener(ClearTowersHandler);
        NextLevelChosenSignal.AddListener(ClearTowersHandler);
        RenewTowerDataSignal.AddListener(RenewDataHandler);
        EnemyDestroyedSignal.AddListener(RemoveEnemyHandler);
    }
    
    public override void OnRemove()
    {
        RestartLevelChosenSignal.RemoveListener(ClearTowersHandler);
        NextLevelChosenSignal.RemoveListener(ClearTowersHandler);
        RenewTowerDataSignal.RemoveListener(RenewDataHandler);
        EnemyDestroyedSignal.RemoveListener(RemoveEnemyHandler);
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
            if (View.EnemyViews.Where(x => !x.IsTarget).Any())
            {
                NearestEnemyFinder finder = new NearestEnemyFinder();
                finder.GetNearestEnemy(towerModel, View);
                if (finder.NearestEnemy != null)
                {
                    View.TowerShoot(View, towerModel, finder.NearestEnemy.Value);
                    yield return new WaitForSeconds(towerModel.ShootDelay);
                }
                else
                {
                    View.RenewData();
                    break;
                }
            }
            else
            {
                View.RenewData();
                break;
            }
        }
        
        View.RenewData();
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
