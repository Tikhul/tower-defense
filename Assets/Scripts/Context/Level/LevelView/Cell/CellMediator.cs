using context.level;
using context.ui;
using strange.extensions.mediation.impl;
using System.Linq;

public class CellMediator : Mediator
{
    [Inject] public CellView View { get; set; }
    [Inject] public BlockBoardSignal BlockBoardSignal { get; set; }
    [Inject] public UnblockBoardSignal UnblockBoardSignal { get; set; }
    [Inject] public StartShootingSignal StartShootingSignal { get; set; }
    [Inject] public DefineEnemyWaySignal DefineEnemyWaySignal { get; set; }
    [Inject] public RestartLevelChosenSignal RestartLevelChosenSignal { get; set; }
    [Inject] public LevelsPipelineModel LevelsPipelineModel { get; set; }
    
    public override void OnRegister()
    {
        BlockBoardSignal.AddListener(BlockBoardHandler);
        UnblockBoardSignal.AddListener(UnblockBoardHandler);
        View.OnShoot += PrepareForShootHandler;
        DefineEnemyWaySignal.AddListener(DefineEnemyWayHandler);
        RestartLevelChosenSignal.AddListener(RestartLevelChosenHandler);
    }
    public override void OnRemove()
    {
        BlockBoardSignal.RemoveListener(BlockBoardHandler);
        UnblockBoardSignal.RemoveListener(UnblockBoardHandler);
        View.OnShoot -= PrepareForShootHandler;
        DefineEnemyWaySignal.RemoveListener(DefineEnemyWayHandler);
        RestartLevelChosenSignal.RemoveListener(RestartLevelChosenHandler);
    }

    private void BlockBoardHandler()
    {
        View.BlockCell();
    }
    private void UnblockBoardHandler()
    {
        View.UnblockCell();
    }

    private void DefineEnemyWayHandler()
    {
        DefineEnemyWay();
    }

    private void RestartLevelChosenHandler()
    {
        DefineEnemyWay();
    }
    
    private void DefineEnemyWay()
    {
        ClearCell(); 
        var _indices = LevelsPipelineModel.CurrentLevel.EnemyWay.Config.Indices;

        for (int i = 0; i< _indices.Count; i++)
        {
            var index = _indices[i];
            if (index.Equals(View.CellInt.ToString() + View.CellChar.ToString()))
            {
                View.State = CellState.EnemyWay;
                View.OrderIndex = i;
                View.DrawEnemyWay();
                break;
            }
        }
    }

    private void ClearCell()
    {
        View.State = CellState.Empty;
        View.Interactable = true;
        View.ClearColor();
    }
    
    private void PrepareForShootHandler(TowerView towerView)
    {
        if (towerView.EnemyViews.Any())
        {
            towerView.IsShooting = true;
            StartShootingSignal.Dispatch();
        }
    }
}
