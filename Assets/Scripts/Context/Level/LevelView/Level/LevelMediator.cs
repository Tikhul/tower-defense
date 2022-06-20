using strange.extensions.mediation.impl;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelMediator : Mediator
{
    [Inject] public LevelView View { get; set; }
    [Inject] public LevelsPipelineModel LevelsPipelineModel { get; set; }
   // [Inject] public PipelineStartSignal PipelineStartSignal { get; set; }
   // [Inject] public PipelineEndedSignal PipelineEndedSignal { get; set; }

    public override void OnRegister()
    {
  //      PipelineStartSignal.AddListener(PipelineStartedHandler);
    }

    public override void OnRemove()
    {
  //      PipelineStartSignal.RemoveListener(PipelineStartedHandler);
        LevelsPipelineModel.OnPipelineComplete -= OnPipelineCompleteHandler;
    }

    private void PipelineStartedHandler()
    {
        LevelsPipelineModel.OnPipelineComplete += OnPipelineCompleteHandler;
    }

    private void OnPipelineCompleteHandler()
    {
      //  PipelineEndedSignal.Dispatch();
    }
}
