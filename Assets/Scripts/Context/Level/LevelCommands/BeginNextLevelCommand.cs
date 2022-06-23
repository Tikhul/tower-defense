using strange.extensions.command.impl;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BeginNextLevelCommand : Command
{
    [Inject] public LevelsPipelineModel LevelsPipelineModel { get; set; }
    public override void Execute()
    {
        LevelsPipelineModel.BeginNextLevel();
        injectionBinder.GetInstance<PassLevelDataSignal>().Dispatch(LevelsPipelineModel.CurrentLevel);
        injectionBinder.GetInstance<DrawEnemyWaySignal>().Dispatch();
    }
}
