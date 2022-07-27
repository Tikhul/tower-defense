using context.level;
using context.ui;
using DG.Tweening;
using strange.extensions.mediation.impl;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class EnemyMediator : Mediator
{
    [Inject] public EnemyView View { get; set; }
    [Inject] public LevelsPipelineModel LevelsPipelineModel { get; set; }
    [Inject] public NextLevelChosenSignal NextLevelChosenSignal { get; set; }
    [Inject] public RestartLevelChosenSignal RestartLevelChosenSignal { get; set; }
    [Inject] public GameModel GameModel { get; set; }
    [Inject] public WaveEndedSignal WaveEndedSignal { get; set; }
    [Inject] public ChangePlayerHealthSignal ChangePlayerHealthSignal { get; set; }
    [Inject] public PrepareForShootSignal PrepareForShootSignal { get; set; }
    [Inject] public CollectEnemiesTransformsSignal CollectEnemiesTransformsSignal { get; set; }
    [Inject] public ChangeEnemyHealthSignal ChangeEnemyHealthSignal { get; set; }
    public override void OnRegister()
    {
        LevelsPipelineModel.CurrentLevel.LevelWaves.EnemiesOnScene.Add(View);
        FillWayPointsHandler();
        NextLevelChosenSignal.AddListener(ClearEnemiesHandler);
        RestartLevelChosenSignal.AddListener(ClearEnemiesHandler);
        View.OnLastEnemy += WaveFinishedHandler;
        View.OnEnemyWayCompleted += ChangePlayerHealthHandler;
        PrepareForShootSignal.AddListener(PredictEnemyTransform);
        ChangeEnemyHealthSignal.AddListener(DamageEnemyHandler);
    }
    public override void OnRemove()
    {
        LevelsPipelineModel.CurrentLevel.LevelWaves.EnemiesOnScene.Remove(View);
        NextLevelChosenSignal.RemoveListener(ClearEnemiesHandler);
        RestartLevelChosenSignal.RemoveListener(ClearEnemiesHandler);
        PrepareForShootSignal.RemoveListener(PredictEnemyTransform);
        View.OnEnemyWayCompleted -= ChangePlayerHealthHandler;
        ChangeEnemyHealthSignal.RemoveListener(DamageEnemyHandler);
    }
    private void FillWayPointsHandler()
    {
        View.FillWayPoints(LevelsPipelineModel.CurrentLevel.EnemyWay
            .GetEnemyWayTransforms(GameModel.Board.CurrentCellList.Where(x=>x.State.Equals(CellState.EnemyWay))
            .OrderBy(x=>x.OrderIndex)
            .ToList()));
    }
    private void ClearEnemiesHandler()
    {
        View.ClearEnemies();
    }
    private void WaveFinishedHandler()
    {
        WaveEndedSignal.Dispatch();
    }
    private void ChangePlayerHealthHandler(int _damage)
    {
        ChangePlayerHealthSignal.Dispatch(_damage);
    }
    private void DamageEnemyHandler(int _damage)
    {
        View.Damage(_damage);
    }
    private void PredictEnemyTransform(TowerModel _tower)
    {
        Debug.Log("PredictEnemyTransform");
        
        var elapsedPercentage = View.EnemyTween.ElapsedPercentage();
        var addPercentage = _tower.ShootDelay / View.EnemyTween.Duration();

        if ((elapsedPercentage + addPercentage) < 1)
        {
            var getPoint = View.EnemyTween.PathGetPoint(elapsedPercentage + addPercentage);
            CollectEnemiesTransformsSignal.Dispatch(getPoint, _tower);
        }
    }
}
