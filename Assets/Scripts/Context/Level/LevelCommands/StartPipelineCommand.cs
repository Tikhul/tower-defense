using strange.extensions.command.impl;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartPipelineCommand : Command
{
    [Inject] public LevelsLibraryModel LevelsLibraryModel { get; set; }
    [Inject] public LevelsPipelineModel LevelsPipelineModel { get; set; }
    public override void Execute()
    {
        LevelsPipelineModel.Config = LevelsLibraryModel.GetLibraryDataById("pipeline");
        LevelsPipelineModel.Begin();
        injectionBinder.GetInstance<DrawEnemyWaySignal>().Dispatch();
        Debug.Log("StartPipelineCommand");
    }
}
