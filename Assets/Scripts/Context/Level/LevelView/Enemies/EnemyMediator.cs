using context.level;
using context.ui;
using strange.extensions.mediation.impl;
using System.Linq;

public class EnemyMediator : Mediator
{
    [Inject] public EnemyView View { get; set; }
    [Inject] public LevelsPipelineModel LevelsPipelineModel { get; set; }
    [Inject] public NextLevelChosenSignal NextLevelChosenSignal { get; set; }
    [Inject] public RestartLevelChosenSignal RestartLevelChosenSignal { get; set; }
    [Inject] public GameModel GameModel { get; set; }
    [Inject] public EnemyDestroyedSignal EnemyDestroyedSignal { get; set; }
    [Inject] public EnemyWayCompletedSignal EnemyWayCompletedSignal { get; set; }
    
    public override void OnRegister()
    {
        FillWayPointsHandler();
        NextLevelChosenSignal.AddListener(ClearEnemiesHandler);
        RestartLevelChosenSignal.AddListener(ClearEnemiesHandler);
        View.OnEnemyWayCompleted += EnemyWayFinishedHandler;
        View.OnEnemyDestroyed += EnemyDestroyedHandler;
    }
    public override void OnRemove()
    {
        NextLevelChosenSignal.RemoveListener(ClearEnemiesHandler);
        RestartLevelChosenSignal.RemoveListener(ClearEnemiesHandler);
        View.OnEnemyWayCompleted -= EnemyWayFinishedHandler;
        View.OnEnemyDestroyed -= EnemyDestroyedHandler;
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
        View.DestroyEnemy();
    }
    private void EnemyWayFinishedHandler()
    {
        EnemyWayCompletedSignal.Dispatch(View);
    }

    private void EnemyDestroyedHandler(EnemyView enemy)
    {
        EnemyDestroyedSignal.Dispatch(enemy);
    }
}
