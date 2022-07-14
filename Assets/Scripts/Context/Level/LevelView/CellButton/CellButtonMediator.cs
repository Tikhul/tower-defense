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
    public override void OnRegister()
    {
        BlockBoardSignal.AddListener(BlockButtonHandler);
        UnblockBoardSignal.AddListener(UnblockButtonHandler);
        RestartLevelChosenSignal.AddListener(ClearButtonHandler);
        NextLevelChosenSignal.AddListener(ClearButtonHandler);
    }
    public override void OnRemove()
    {
        BlockBoardSignal.RemoveListener(BlockButtonHandler);
        UnblockBoardSignal.RemoveListener(UnblockButtonHandler);
        RestartLevelChosenSignal.RemoveListener(ClearButtonHandler);
        NextLevelChosenSignal.RemoveListener(ClearButtonHandler);
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
    // TODO: перенести все из BoardMediator
}
