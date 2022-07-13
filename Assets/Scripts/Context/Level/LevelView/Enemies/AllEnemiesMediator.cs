using context.level;
using strange.extensions.mediation.impl;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AllEnemiesMediator : Mediator
{
    [Inject] public AllEnemiesView View { get; set; }
    [Inject] public LevelsPipelineModel LevelsPipelineModel { get; set; }
    [Inject] public CreateEnemiesSignal CreateEnemiesSignal { get; set; }
    public override void OnRegister()
    {
        Debug.Log("OnRegister");
        LevelsPipelineModel.CurrentLevel.LevelWaves.CurrentWave.OnWaveBegin += CreateEnemiesHandler;
    }
    public override void OnRemove()
    {
        LevelsPipelineModel.CurrentLevel.LevelWaves.CurrentWave.OnWaveBegin -= CreateEnemiesHandler;
    }
    private void CreateEnemiesHandler()
    {
        Debug.Log("CreateEnemiesHandler");
        CreateEnemiesSignal.Dispatch(LevelsPipelineModel.CurrentLevel.LevelWaves.CurrentWave.EnemiesAmounts);
    }
}
