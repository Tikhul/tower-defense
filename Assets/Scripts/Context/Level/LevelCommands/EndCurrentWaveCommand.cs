using strange.extensions.command.impl;
using System.Linq;
using context.level;
using UnityEngine;

public class EndCurrentWaveCommand : Command
{
    private ILevelModel CurrentLevel => injectionBinder.GetInstance<LevelsPipelineModel>().CurrentLevel;
    public override void Execute()
    {
        Debug.Log("EndCurrentWaveCommand");
        Debug.Log(injectionBinder.GetInstance<GameModel>().Player.ActualHealth);
        CurrentLevel.LevelWaves.CompleteCurrentWave();
        var completedWaves = CurrentLevel.LevelWaves.WaveModels.Where(
            x => x.State.Equals(WaveState.Completed)).ToList();
        
        if(completedWaves.Count == CurrentLevel.LevelWaves.WaveModels.Count && 
           injectionBinder.GetInstance<GameModel>().Player.ActualHealth > 0)
        {
            injectionBinder.GetInstance<LevelEndedSignal>().Dispatch();
            Fail();
        }
        else if (completedWaves.Count == CurrentLevel.LevelWaves.WaveModels.Count && 
                 injectionBinder.GetInstance<GameModel>().Player.ActualHealth <= 0)
        {
            injectionBinder.GetInstance<PipelineEndedSignal>().Dispatch();
            Fail();
        }
    }
}
