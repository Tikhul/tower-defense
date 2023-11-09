using strange.extensions.command.impl;
using UnityEngine;

public class SaveEnemyWayTransformCommand : Command
{
    [Inject] public Vector3 Transform { get; set; }
    
    public override void Execute()
    {
        var levelsPipelineModel = injectionBinder.GetInstance<LevelsPipelineModel>();
        levelsPipelineModel.CurrentLevel.EnemyWay.AddEnemyWayTransform(Transform);
    }
}
