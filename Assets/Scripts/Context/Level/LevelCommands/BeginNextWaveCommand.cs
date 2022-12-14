using context.level;
using strange.extensions.command.impl;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BeginNextWaveCommand : Command
{
    public override void Execute()
    {
        injectionBinder.GetInstance<LevelsPipelineModel>().CurrentLevel.LevelWaves.BeginNextWave();
        injectionBinder.GetInstance<ActivateWaveSignal>().Dispatch();
        Debug.Log("BeginNextWaveCommand");
    }
    
}
