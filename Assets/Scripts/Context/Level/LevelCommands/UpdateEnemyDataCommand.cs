using System.Collections.Generic;
using strange.extensions.command.impl;

public class UpdateEnemyDataCommand : Command
{
    [Inject] public EnemyView EnemyView { get; set; }
    private Dictionary<EnemyView, EnemyModel> _enemyData => injectionBinder.GetInstance<LevelsPipelineModel>()
        .CurrentLevel.LevelWaves.CurrentWave.EnemyData;
    public override void Execute()
    {
        _enemyData.Remove(EnemyView);
        EnemyView.DestroyEnemy();
    }
}
