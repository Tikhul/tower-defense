using strange.extensions.mediation.impl;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoardMediator : Mediator
{
    [Inject] public BoardView View { get; set; }
    [Inject] public DrawBoardSignal DrawBoardSignal { get; set; }
    [Inject] public ShowRestartPanelSignal ShowRestartPanelSignal { get; set; }
    [Inject] public PipelineEndedSignal PipelineEndedSignal { get; set; }

    public override void OnRegister()
    {
        DrawBoardSignal.Dispatch(View.BoardParent);
        ShowRestartPanelSignal.AddListener(HideStartPanel);
        PipelineEndedSignal.AddListener(HideStartPanel);
    }

    public override void OnRemove()
    {
        ShowRestartPanelSignal.RemoveListener(HideStartPanel);
        PipelineEndedSignal.RemoveListener(HideStartPanel);
    }
    private void HideStartPanel()
    {
        View.Hide();
    }
}
