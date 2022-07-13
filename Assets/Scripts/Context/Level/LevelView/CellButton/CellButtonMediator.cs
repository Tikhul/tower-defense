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
    public override void OnRegister()
    {
        BlockBoardSignal.AddListener(BlockButtonHandler);
        UnblockBoardSignal.AddListener(UnblockButtonHandler);
    }
    public override void OnRemove()
    {
        BlockBoardSignal.RemoveListener(BlockButtonHandler);
        UnblockBoardSignal.RemoveListener(UnblockButtonHandler);
    }
    private void BlockButtonHandler()
    {
        View.BlockButton();
    }
    private void UnblockButtonHandler()
    {
        View.UnblockButton();
    }
    // TODO: перенести все из BoardMediator
}
