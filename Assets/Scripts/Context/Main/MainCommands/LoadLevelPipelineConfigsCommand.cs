using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoadLevelPipelineConfigsCommand : LoadConfigsCommand<LevelsLibraryModel, LevelsPipelineSO>
{
    protected override string GetPath()
    {
        return StaticName.PIPELINES_PATH;
    }
}
