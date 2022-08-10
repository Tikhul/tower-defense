using context.level;
using context.ui;
using strange.extensions.mediation.impl;
using System.Linq;

public class CellMediator : Mediator
{
    [Inject] public CellView View { get; set; }
    [Inject] public OnEnemyWayDefinedSignal OnEnemyWayDefinedSignal { get; set; }
    [Inject] public BlockBoardSignal BlockBoardSignal { get; set; }
    [Inject] public UnblockBoardSignal UnblockBoardSignal { get; set; }
    [Inject] public PrepareForShootSignal PrepareForShootSignal { get; set; }
    [Inject] public LevelsPipelineModel LevelsPipelineModel { get; set; }
    public override void OnRegister()
    {
        DrawEnemyHandler();
        OnEnemyWayDefinedSignal.AddListener(DrawEnemyHandler);
        BlockBoardSignal.AddListener(BlockCellHandler);
        UnblockBoardSignal.AddListener(UnblockCellHander);
        View.OnShoot += PrepareForShootHandler;
    }
    public override void OnRemove()
    {
        OnEnemyWayDefinedSignal.RemoveListener(DrawEnemyHandler);
        BlockBoardSignal.RemoveListener(BlockCellHandler);
        UnblockBoardSignal.RemoveListener(UnblockCellHander);
        View.OnShoot -= PrepareForShootHandler;
    }
    private void DrawEnemyHandler()
    {
        View.DrawEnemyWay();
    }
    private void BlockCellHandler()
    {
        View.BlockCell();
    }
    private void UnblockCellHander()
    {
        View.UnblockCell();
    }
    private void PrepareForShootHandler(TowerView towerView)
    {
        if (towerView.EnemyViews.Any())
        {
            towerView.IsShooting = true;
            var towerModel = LevelsPipelineModel.CurrentLevel.TowerData[towerView];
            PrepareForShootSignal.Dispatch(towerModel, towerView);
        }
    }
}