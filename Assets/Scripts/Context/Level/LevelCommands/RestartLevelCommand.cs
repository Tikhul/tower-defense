using context.level;
using strange.extensions.command.impl;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RestartLevelCommand : Command
{
    private LevelsPipelineModel LevelsPipelineModel => injectionBinder.GetInstance<LevelsPipelineModel>();
    public override void Execute()
    {
        LevelsPipelineModel.CurrentLevel.TowerData.Clear();
        LevelsPipelineModel.RestartLevel();
        injectionBinder.GetInstance<ActivateWaveSignal>().Dispatch();
    }
}
