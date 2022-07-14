using context.level;
using context.ui;
using strange.extensions.mediation.impl;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CellButtonMediator : Mediator
{
    [Inject] public CellButtonView View { get; set; }
    [Inject] public BlockBoardSignal BlockBoardSignal { get; set; }
    [Inject] public UnblockBoardSignal UnblockBoardSignal { get; set; }
    [Inject] public RestartLevelChosenSignal RestartLevelChosenSignal { get; set; }
    [Inject] public NextLevelChosenSignal NextLevelChosenSignal { get; set; }
    [Inject] public OnEnemyWayDefinedSignal OnEnemyWayDefinedSignal { get; set; }
    [Inject] public DrawEnemyWaySignal DrawEnemyWaySignal { get; set; }
    public override void OnRegister()
    {
        DrawEnemyWaySignal.Dispatch();
        BlockBoardSignal.AddListener(BlockButtonHandler);
        UnblockBoardSignal.AddListener(UnblockButtonHandler);
        RestartLevelChosenSignal.AddListener(ClearButtonHandler);
        NextLevelChosenSignal.AddListener(ClearButtonHandler);
        OnEnemyWayDefinedSignal.AddListener(DrawEnemyHandler);
    }
    public override void OnRemove()
    {
        BlockBoardSignal.RemoveListener(BlockButtonHandler);
        UnblockBoardSignal.RemoveListener(UnblockButtonHandler);
        RestartLevelChosenSignal.RemoveListener(ClearButtonHandler);
        NextLevelChosenSignal.RemoveListener(ClearButtonHandler);
        OnEnemyWayDefinedSignal.RemoveListener(DrawEnemyHandler);
    }
    private void BlockButtonHandler()
    {
        View.BlockButton();
    }
    private void UnblockButtonHandler()
    {
        View.UnblockButton();
    }
    private void ClearButtonHandler()
    {
        View.ClearButton();
    }
    private void DrawEnemyHandler()
    {
        View.DrawEnemyWay();
    }
}
