using context.level;
using strange.extensions.command.impl;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RestartLevelCommand : Command
{
    public override void Execute()
    {
        injectionBinder.GetInstance<LevelsPipelineModel>().RestartLevel();
    }
}
