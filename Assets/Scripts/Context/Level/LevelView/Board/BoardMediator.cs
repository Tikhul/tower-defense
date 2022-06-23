using strange.extensions.mediation.impl;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoardMediator : Mediator
{
    [Inject] public BoardView View { get; set; }
    [Inject] public GameModel GameModel { get; set; }
    [Inject] public LevelsPipelineModel LevelsPipelineModel { get; set; }
    [Inject] public DrawBoardSignal DrawBoardSignal { get; set; }
    [Inject] public DrawEnemyWaySignal DrawEnemyWaySignal { get; set; }
    [Inject] public ShowRestartPanelSignal ShowRestartPanelSignal { get; set; }
    [Inject] public PipelineEndedSignal PipelineEndedSignal { get; set; }
    [Inject] public RestartLevelChosenSignal RestartLevelChosenSignal { get; set; }
    [Inject] public NextLevelChosenSignal NextLevelChosenSignal { get; set; }
    [Inject] public BlockBoardSignal BlockBoardSignal { get; set; }
    [Inject] public UnblockBoardSignal UnblockBoardSignal { get; set; }

    public override void OnRegister()
    {
        DrawBoardSignal.Dispatch(View.BoardParent);
        DrawEnemyWaySignal.AddListener(DrawEnemiesHandler);
        RestartLevelChosenSignal.AddListener(ShowPanelHandler);
        NextLevelChosenSignal.AddListener(ShowPanelHandler);
        ShowRestartPanelSignal.AddListener(HidePanelHandler);
        PipelineEndedSignal.AddListener(HidePanelHandler);
        PipelineEndedSignal.AddListener(Unsubscribe);
        BlockBoardSignal.AddListener(BlockBoardHandler);
        UnblockBoardSignal.AddListener(UnBlockBoardHandler);
    }

    public override void OnRemove()
    {
        RestartLevelChosenSignal.RemoveListener(ShowPanelHandler);
        NextLevelChosenSignal.RemoveListener(ShowPanelHandler);
        ShowRestartPanelSignal.RemoveListener(HidePanelHandler);
        PipelineEndedSignal.RemoveListener(HidePanelHandler);
        PipelineEndedSignal.RemoveListener(Unsubscribe);
        BlockBoardSignal.RemoveListener(BlockBoardHandler);
        UnblockBoardSignal.RemoveListener(UnBlockBoardHandler);
    }
    private void HidePanelHandler()
    {
        View.Hide();
    }

    private void ShowPanelHandler()
    {
        View.Show();
    }

    private void DrawEnemiesHandler()
    {
        View.DrawEnemiesWays(GameModel.Board.CurrentCellList);
        Debug.Log("DrawEnemiesHandler");
    }

    private void Unsubscribe()
    {
        DrawEnemyWaySignal.RemoveListener(DrawEnemiesHandler);
    }

    private void BlockBoardHandler()
    {
        View.BlockBoard();
    }
    private void UnBlockBoardHandler()
    {
        View.UnblockBoard();
    }
}
