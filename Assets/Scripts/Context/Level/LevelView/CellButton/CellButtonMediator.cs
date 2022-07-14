using context.level;
using context.ui;
using strange.extensions.mediation.impl;
using UnityEngine;

public class CellButtonMediator : Mediator
{
    [Inject] public CellButtonView View { get; set; }
    [Inject] public BlockBoardSignal BlockBoardSignal { get; set; }
    [Inject] public UnblockBoardSignal UnblockBoardSignal { get; set; }
    [Inject] public RestartLevelChosenSignal RestartLevelChosenSignal { get; set; }
    [Inject] public NextLevelChosenSignal NextLevelChosenSignal { get; set; }
    [Inject] public OnEnemyWayDefinedSignal OnEnemyWayDefinedSignal { get; set; }
    [Inject] public ActivateEnemySignal ActivateEnemySignal { get; set; }
    public override void OnRegister()
    {
        DrawEnemyHandler();
        BlockBoardSignal.AddListener(BlockButtonHandler);
        UnblockBoardSignal.AddListener(UnblockButtonHandler);
        RestartLevelChosenSignal.AddListener(ClearButtonHandler);
        NextLevelChosenSignal.AddListener(ClearButtonHandler);
        OnEnemyWayDefinedSignal.AddListener(DrawEnemyHandler);
        ActivateEnemySignal.AddListener(ActivateEnemyHandler);
    }
    public override void OnRemove()
    {
        BlockBoardSignal.RemoveListener(BlockButtonHandler);
        UnblockBoardSignal.RemoveListener(UnblockButtonHandler);
        RestartLevelChosenSignal.RemoveListener(ClearButtonHandler);
        NextLevelChosenSignal.RemoveListener(ClearButtonHandler);
        OnEnemyWayDefinedSignal.RemoveListener(DrawEnemyHandler);
        ActivateEnemySignal.RemoveListener(ActivateEnemyHandler);
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
    private void ActivateEnemyHandler(string receivedIndex, EnemyModel receivedEnemy)
    {
        if(receivedIndex.Equals(View.CellInt.ToString() + View.CellChar.ToString()))
        {
            View.ActivateEnemy(receivedEnemy);
        }
    }
}
