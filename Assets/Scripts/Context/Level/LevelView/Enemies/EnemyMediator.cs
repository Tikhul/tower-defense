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
    [Inject] public ChangeEnemyHealthSignal ChangeEnemyHealthSignal { get; set; }
    public override void OnRegister()
    {
        LevelsPipelineModel.CurrentLevel.LevelWaves.CurrentWave.EnemiesOnScene.Add(View);
        FillWayPointsHandler();
        NextLevelChosenSignal.AddListener(ClearEnemiesHandler);
        RestartLevelChosenSignal.AddListener(ClearEnemiesHandler);
        View.OnEnemyDestroy += WaveFinishedHandler;
        View.OnEnemyWayCompleted += ChangePlayerHealthHandler;
        ChangeEnemyHealthSignal.AddListener(DamageEnemyHandler);
    }
    public override void OnRemove()
    {
        LevelsPipelineModel.CurrentLevel.LevelWaves.CurrentWave.EnemiesOnScene.Remove(View);
        NextLevelChosenSignal.RemoveListener(ClearEnemiesHandler);
        RestartLevelChosenSignal.RemoveListener(ClearEnemiesHandler);
        View.OnEnemyWayCompleted -= ChangePlayerHealthHandler;
        ChangeEnemyHealthSignal.RemoveListener(DamageEnemyHandler);
        View.OnEnemyDestroy -= WaveFinishedHandler;
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
        if (LevelsPipelineModel.CurrentLevel.LevelWaves.CurrentWave.EnemiesOnScene.Count == 1)
        {
            WaveEndedSignal.Dispatch();
        }
    }
    private void ChangePlayerHealthHandler(int _damage)
    {
        ChangePlayerHealthSignal.Dispatch(_damage);
    }
    private void DamageEnemyHandler(int _damage)
    {
        View.Damage(_damage);
    }
}
