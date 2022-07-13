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
    [Inject] public LevelsPipelineModel LevelsPipelineModel { get; set; }
    [Inject] public DrawBoardSignal DrawBoardSignal { get; set; }
    [Inject] public DrawEnemyWaySignal DrawEnemyWaySignal { get; set; }
    [Inject] public ShowRestartPanelSignal ShowRestartPanelSignal { get; set; }
    [Inject] public PipelineEndedSignal PipelineEndedSignal { get; set; }
    [Inject] public RestartLevelChosenSignal RestartLevelChosenSignal { get; set; }
    [Inject] public NextLevelChosenSignal NextLevelChosenSignal { get; set; }
    [Inject] public BlockBoardSignal BlockBoardSignal { get; set; }
    [Inject] public UnblockBoardSignal UnblockBoardSignal { get; set; }
    [Inject] public OnEnemyDrawnSignal OnEnemyDrawnSignal { get; set; }

    public override void OnRegister()
    {
        DrawBoardSignal.Dispatch(View.BoardParent);
        OnEnemyDrawnSignal.AddListener(DrawEnemiesHandler);
        DrawEnemyWaySignal.Dispatch();
        RestartLevelChosenSignal.AddListener(LevelStartHandler);
        NextLevelChosenSignal.AddListener(LevelStartHandler);
        ShowRestartPanelSignal.AddListener(HidePanel);
        PipelineEndedSignal.AddListener(PipelineEndedHandler);
        BlockBoardSignal.AddListener(BlockBoard);
        UnblockBoardSignal.AddListener(UnBlockBoard);
    }

    public override void OnRemove()
    {
        RestartLevelChosenSignal.RemoveListener(LevelStartHandler);
        NextLevelChosenSignal.RemoveListener(LevelStartHandler);
        ShowRestartPanelSignal.RemoveListener(HidePanel);
        PipelineEndedSignal.RemoveListener(PipelineEndedHandler);
        BlockBoardSignal.RemoveListener(BlockBoard);
        UnblockBoardSignal.RemoveListener(UnBlockBoard);
    }
    private void LevelStartHandler()
    {
        ClearTowers();
        ShowPanel();
    }

    private void PipelineEndedHandler()
    {
        HidePanel();
        Unsubscribe();
    }
    private void DrawEnemiesHandler()
    {
        View.DrawEnemiesWays(GameModel.Board.CurrentCellList);
    }

    private void Unsubscribe()
    {
        OnEnemyDrawnSignal.RemoveListener(DrawEnemiesHandler);
    }

    private void BlockBoard()
    {
        View.BlockBoard();
    }
    private void UnBlockBoard()
    {
        View.UnblockBoard();
    }
    private void HidePanel()
    {
        View.Hide();
    }

    private void ShowPanel()
    {
        View.Show();
    }
    private void ClearTowers()
    {
        List<CellButtonView> buttonsWithTowers = GameModel.Board.CurrentCellList.FindAll(x => x.State == CellState.HasTower);
        View.ClearTowers(buttonsWithTowers);
    }
}
