using strange.extensions.injector.impl;
using strange.extensions.mediation.impl;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelMediator : Mediator
{
    [Inject] public LevelView View { get; set; }
    [Inject] public LevelsPipelineModel LevelsPipelineModel { get; set; }
    [Inject] public ShowRestartPanelSignal ShowRestartPanelSignal { get; set; }
    [Inject] public PipelineEndedSignal PipelineEndedSignal { get; set; }
    [Inject] public ShowEndPanelSignal ShowEndPanelSignal { get; set; }

    public override void OnRegister()
    {
        View.OnSpaceClick += NexStageHandler;
        LevelsPipelineModel.OnPipelineBegin += OnPipelineBeginHandler;
        LevelsPipelineModel.OnPipelineComplete += OnPipelineCompleteHandler;
    }

    public override void OnRemove()
    {
        
    }

    private void NexStageHandler()
    {
        //  LevelsPipelineModel.CompleteCurrentLevel();
        // LevelsPipelineModel.BeginNextLevel();
        ShowRestartPanelSignal.Dispatch();
    }

    private void OnPipelineBeginHandler()
    {
 
    }
    private void OnPipelineCompleteHandler()
    {
        PipelineEndedSignal.Dispatch();
        ShowEndPanelSignal.Dispatch();
        View.OnSpaceClick -= NexStageHandler;
        LevelsPipelineModel.OnPipelineBegin -= OnPipelineBeginHandler;
        LevelsPipelineModel.OnPipelineComplete -= OnPipelineCompleteHandler;
        Debug.Log("OnPipelineCompleteHandler");
    }
}
