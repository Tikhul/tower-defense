using strange.extensions.command.impl;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using context.level;

public class EndCurrentWaveCommand : Command
{
    private ILevelModel CurrentLevel => injectionBinder.GetInstance<LevelsPipelineModel>().CurrentLevel;
    public override void Execute()
    {
        CurrentLevel.LevelWaves.CompleteCurrentWave();
        if(CurrentLevel.LevelWaves.WaveModels.Where(x => x.State.Equals(WaveState.Completed)).ToList().Count.Equals(
            CurrentLevel.LevelWaves.WaveModels.Count))
        {
            injectionBinder.GetInstance<LevelEndedSignal>().Dispatch();
            Fail();
        }
    }
}
