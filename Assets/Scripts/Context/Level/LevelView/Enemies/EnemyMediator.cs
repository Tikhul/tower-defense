using context.level;
using context.ui;
using strange.extensions.mediation.impl;

public class EnemyMediator : Mediator
{
    [Inject] public EnemyView View { get; set; }
    [Inject] public LevelsPipelineModel LevelsPipelineModel { get; set; }
    [Inject] public NextLevelChosenSignal NextLevelChosenSignal { get; set; }
    [Inject] public RestartLevelChosenSignal RestartLevelChosenSignal { get; set; }
    [Inject] public EnemyWayCompletedSignal EnemyWayCompletedSignal { get; set; }
    
    public override void OnRegister()
    {
        FillWayPointsHandler();
        NextLevelChosenSignal.AddListener(ClearEnemiesHandler);
        RestartLevelChosenSignal.AddListener(ClearEnemiesHandler);
        View.OnEnemyWayCompleted += EnemyWayFinishedHandler;
    }
    public override void OnRemove()
    {
        NextLevelChosenSignal.RemoveListener(ClearEnemiesHandler);
        RestartLevelChosenSignal.RemoveListener(ClearEnemiesHandler);
        View.OnEnemyWayCompleted -= EnemyWayFinishedHandler;
    }
    private void FillWayPointsHandler()
    {
        View.FillWayPoints(LevelsPipelineModel.CurrentLevel.EnemyWay.EnemyWayTransforms);
    }
    private void ClearEnemiesHandler()
    {
        View.DestroyEnemy();
    }
    private void EnemyWayFinishedHandler()
    {
        EnemyWayCompletedSignal.Dispatch(View);
    }
}
