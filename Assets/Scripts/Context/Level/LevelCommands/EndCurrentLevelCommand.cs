using strange.extensions.command.impl;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndCurrentLevelCommand : Command
{
    public override void Execute()
    {
        injectionBinder.GetInstance<LevelsPipelineModel>().CompleteCurrentLevel();
    }
}
