using context.level;
using context.ui;
using strange.extensions.mediation.impl;
using System.Linq;
using UnityEngine;

public class CellMediator : Mediator
{
    [Inject] public CellView View { get; set; }
    [Inject] public OnEnemyWayDefinedSignal OnEnemyWayDefinedSignal { get; set; }
    [Inject] public BlockBoardSignal BlockBoardSignal { get; set; }
    [Inject] public UnblockBoardSignal UnblockBoardSignal { get; set; }
    [Inject] public StartShootingSignal StartShootingSignal { get; set; }
    
    public override void OnRegister()
    {
        DrawEnemyHandler();
        OnEnemyWayDefinedSignal.AddListener(DrawEnemyHandler);
        BlockBoardSignal.AddListener(BlockCellHandler);
        UnblockBoardSignal.AddListener(UnblockCellHandler);
        View.OnShoot += PrepareForShootHandler;
    }
    public override void OnRemove()
    {
        OnEnemyWayDefinedSignal.RemoveListener(DrawEnemyHandler);
        BlockBoardSignal.RemoveListener(BlockCellHandler);
        UnblockBoardSignal.RemoveListener(UnblockCellHandler);
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
    private void UnblockCellHandler()
    {
        View.UnblockCell();
    }
    private void PrepareForShootHandler(TowerView towerView)
    {
        if (towerView.EnemyViews.Any())
        {
            towerView.IsShooting = true;
            Debug.Log(towerView.IsShooting);
            StartShootingSignal.Dispatch();
        }
    }
}
