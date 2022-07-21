using context.level;
using context.ui;
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
    public override void OnRegister()
    {
        FillWayPointsHandler();
        NextLevelChosenSignal.AddListener(ClearEnemiesHandler);
        RestartLevelChosenSignal.AddListener(ClearEnemiesHandler);
        View.OnLastEnemy += WaveFinishedHandler;
    }
    public override void OnRemove()
    {
        NextLevelChosenSignal.RemoveListener(ClearEnemiesHandler);
        RestartLevelChosenSignal.RemoveListener(ClearEnemiesHandler);
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
}
