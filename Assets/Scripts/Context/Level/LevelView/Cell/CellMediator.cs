using context.level;
using context.ui;
using strange.extensions.mediation.impl;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CellMediator : Mediator
{
    [Inject] public CellView View { get; set; }
    [Inject] public OnEnemyWayDefinedSignal OnEnemyWayDefinedSignal { get; set; }
    [Inject] public BlockBoardSignal BlockBoardSignal { get; set; }
    [Inject] public UnblockBoardSignal UnblockBoardSignal { get; set; }
    public override void OnRegister()
    {
        DrawEnemyHandler();
        OnEnemyWayDefinedSignal.AddListener(DrawEnemyHandler);
        BlockBoardSignal.AddListener(BlockCellHandler);
        UnblockBoardSignal.AddListener(UnblockCellHander);
    }
    public override void OnRemove()
    {
        OnEnemyWayDefinedSignal.RemoveListener(DrawEnemyHandler);
        BlockBoardSignal.RemoveListener(BlockCellHandler);
        UnblockBoardSignal.RemoveListener(UnblockCellHander);
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
    private void ClearButtonHandler()
    {
        View.ClearCell();
    }
}
