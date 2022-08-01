using context.level;
using DG.Tweening;
using strange.extensions.command.impl;
using System.Collections.Generic;
using UnityEngine;

public class PrepareForShootCommand : Command
{
    [Inject] public TowerModel TowerModel { get; set; }
    private List<EnemyView> _enemyViews => injectionBinder.GetInstance<LevelsPipelineModel>().CurrentLevel.LevelWaves.CurrentWave.EnemiesOnScene;
    public override void Execute()
    {
        Dictionary<Vector3, EnemyView> _tempList = new Dictionary<Vector3, EnemyView>();
        foreach (var view in _enemyViews)
        {
            var _percentage = (TowerModel.ShootDelay + view.EnemyTween.Elapsed()) / view.EnemyTween.Duration();

            if (_percentage < 1)
            {
                var getPoint = view.EnemyTween.PathGetPoint(_percentage);
                _tempList.Add(getPoint, view);
            }
        }
        injectionBinder.GetInstance<ReadyToShootSignal>().Dispatch(_tempList, TowerModel);
 //       Debug.Log("PrepareForShootCommand");
    }
}
