using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoadLevelPipelineConfigsCommand : LoadConfigsCommand<LevelsLibraryModel, LevelsPipelineConfig>
{
    protected override string GetPath()
    {
        return StaticName.LEVEL_PIPELINES_PATH;
    }
}
