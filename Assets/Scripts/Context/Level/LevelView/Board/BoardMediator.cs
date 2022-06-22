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

    public override void OnRegister()
    {
        DrawBoardSignal.Dispatch(View.BoardParent);
        DrawEnemyWaySignal.AddListener(DrawEnemiesHandler);
        RestartLevelChosenSignal.AddListener(ShowPanelHandler);
        NextLevelChosenSignal.AddListener(ShowPanelHandler);
        ShowRestartPanelSignal.AddListener(HidePanelHandler);
        PipelineEndedSignal.AddListener(HidePanelHandler);
        PipelineEndedSignal.AddListener(Unsubscribe);
    }

    public override void OnRemove()
    {
        RestartLevelChosenSignal.RemoveListener(ShowPanelHandler);
        NextLevelChosenSignal.RemoveListener(ShowPanelHandler);
        ShowRestartPanelSignal.RemoveListener(HidePanelHandler);
        PipelineEndedSignal.RemoveListener(HidePanelHandler);
        PipelineEndedSignal.RemoveListener(Unsubscribe);
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
        foreach (var cell in GameModel.Board.CurrentCellList) Debug.Log(cell.State);
        Debug.Log("DrawEnemiesHandler");
    }

    private void Unsubscribe()
    {
        DrawEnemyWaySignal.RemoveListener(DrawEnemiesHandler);
    }
}
