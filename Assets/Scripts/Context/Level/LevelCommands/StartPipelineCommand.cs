using context.ui;
using strange.extensions.command.impl;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartPipelineCommand : Command
{
    private LevelsPipelineModel LevelsPipelineModel => injectionBinder.GetInstance<LevelsPipelineModel>();
    public override void Execute()
    {
        LevelsPipelineModel.Config = injectionBinder.GetInstance<LevelsLibraryModel>().GetLibraryDataById("pipeline");
        LevelsPipelineModel.Begin();
        injectionBinder.GetInstance<PassLevelDataSignal>().Dispatch(LevelsPipelineModel.CurrentLevel);
    }
}
