using strange.extensions.mediation.impl;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelMediator : Mediator
{
    [Inject] public LevelView View { get; set; }
    [Inject] public LevelsPipelineModel LevelsPipelineModel { get; set; }
    [Inject] public BeginNextLevelSignal BeginNextLevelSignal { get; set; }

    public override void OnRegister()
    {
        View.OnSpaceClick += NexStageHandler;
        LevelsPipelineModel.OnPipelineBegin += OnPipelineBeginHandler;
        LevelsPipelineModel.OnPipelineComplete += OnPipelineCompleteHandler;
    }

    public override void OnRemove()
    {
        View.OnSpaceClick -= NexStageHandler;
        LevelsPipelineModel.OnPipelineBegin -= OnPipelineBeginHandler;
        LevelsPipelineModel.OnPipelineComplete -= OnPipelineCompleteHandler;
    }

    private void NexStageHandler()
    {
        //  LevelsPipelineModel.CompleteCurrentLevel();
        // LevelsPipelineModel.BeginNextLevel();
        BeginNextLevelSignal.Dispatch();
    }

    private void OnPipelineBeginHandler()
    {

    }
    private void OnPipelineCompleteHandler()
    {
  
    }
}
