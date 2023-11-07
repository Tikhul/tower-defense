using strange.extensions.mediation.impl;
using context.ui;
using context.level;
using UnityEngine;

public class BoardMediator : Mediator
{
    [Inject] public BoardView View { get; set; }
    [Inject] public ShowRestartPanelSignal ShowRestartPanelSignal { get; set; }
    [Inject] public PipelineEndedSignal PipelineEndedSignal { get; set; }
    [Inject] public RestartLevelChosenSignal RestartLevelChosenSignal { get; set; }
    [Inject] public NextLevelChosenSignal NextLevelChosenSignal { get; set; }
    [Inject] public GameModel GameModel { get; set; }
    [Inject] public PipelineStartSignal PipelineStartSignal { get; set; }

    public override void OnRegister()
    {
        ShowPanel();
        RestartLevelChosenSignal.AddListener(StartLevelHandler);
        NextLevelChosenSignal.AddListener(StartLevelHandler);
        ShowRestartPanelSignal.AddListener(HidePanelHandler);
        PipelineEndedSignal.AddListener(HidePanelHandler);
    }

    public override void OnRemove()
    {
        RestartLevelChosenSignal.RemoveListener(StartLevelHandler);
        NextLevelChosenSignal.RemoveListener(StartLevelHandler);
        ShowRestartPanelSignal.RemoveListener(HidePanelHandler);
        PipelineEndedSignal.RemoveListener(HidePanelHandler);
    }

    private void StartLevelHandler()
    {
        ShowPanel();
    }
    
    private void ShowPanel()
    {
        DrawBoard();
        View.Show();
    }

    private void HidePanelHandler()
    {
        View.Hide();
    }

    private void DrawBoard()
    {
        View.DrawCells(GameModel.Board.CellList, GameModel.Board.Settings);
        PipelineStartSignal.Dispatch();
    }
}
