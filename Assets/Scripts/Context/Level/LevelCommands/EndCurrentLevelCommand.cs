using context.level;
using strange.extensions.command.impl;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class EndCurrentLevelCommand : Command
{
    private LevelsPipelineModel LevelsPipelineModel => injectionBinder.GetInstance<LevelsPipelineModel>();
    public override void Execute()
    {
        injectionBinder.GetInstance<LevelsPipelineModel>().CompleteCurrentLevel();
        if (LevelsPipelineModel.LevelModels.Where(x => x.State.Equals(LevelState.Completed)).Count().Equals(
            LevelsPipelineModel.LevelModels.Count))
        {
            injectionBinder.GetInstance<PipelineEndedSignal>().Dispatch();
            Fail();
        }
    }
}
