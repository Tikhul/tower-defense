using strange.extensions.mediation.impl;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using context.ui;
using context.level;

public class BoardMediator : Mediator
{
    [Inject] public BoardView View { get; set; }
    [Inject] public GameModel GameModel { get; set; }
    [Inject] public DrawBoardSignal DrawBoardSignal { get; set; }
    [Inject] public DrawEnemyWaySignal DrawEnemyWaySignal { get; set; }
    [Inject] public ShowRestartPanelSignal ShowRestartPanelSignal { get; set; }
    [Inject] public PipelineEndedSignal PipelineEndedSignal { get; set; }
    [Inject] public RestartLevelChosenSignal RestartLevelChosenSignal { get; set; }
    [Inject] public NextLevelChosenSignal NextLevelChosenSignal { get; set; }
    [Inject] public OnEnemyWayDefinedSignal OnEnemyWayDefinedSignal { get; set; }
    [Inject] public CreateEnemiesSignal CreateEnemiesSignal { get; set; }

    public override void OnRegister()
    {
        DrawBoardSignal.Dispatch(View.BoardParent);
        OnEnemyWayDefinedSignal.AddListener(DrawEnemiesHandler);
        DrawEnemyWaySignal.Dispatch();
        RestartLevelChosenSignal.AddListener(LevelStartHandler);
        NextLevelChosenSignal.AddListener(LevelStartHandler);
        ShowRestartPanelSignal.AddListener(HidePanel);
        PipelineEndedSignal.AddListener(PipelineEndedHandler);
    }

    public override void OnRemove()
    {
        RestartLevelChosenSignal.RemoveListener(LevelStartHandler);
        NextLevelChosenSignal.RemoveListener(LevelStartHandler);
        ShowRestartPanelSignal.RemoveListener(HidePanel);
        PipelineEndedSignal.RemoveListener(PipelineEndedHandler);
    }
    private void LevelStartHandler()
    {
        View.Show();
    }

    private void PipelineEndedHandler()
    {
        HidePanel();
        Unsubscribe();
    }
    private void DrawEnemiesHandler()
    {
        View.DrawEnemiesWays(GameModel.Board.CurrentCellList);
        CreateEnemiesSignal.Dispatch();
    }

    private void Unsubscribe()
    {
        OnEnemyWayDefinedSignal.RemoveListener(DrawEnemiesHandler);
    }

    private void HidePanel()
    {
        View.Hide();
    }
}
