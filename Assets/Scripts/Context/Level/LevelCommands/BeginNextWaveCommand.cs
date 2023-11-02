using context.level;
using strange.extensions.command.impl;
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
