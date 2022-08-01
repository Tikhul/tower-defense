using context.level;
using DG.Tweening;
using strange.extensions.command.impl;
using System.Collections.Generic;
using UnityEngine;

public class PrepareForShootCommand : Command
{
    [Inject] public TowerModel TowerModel { get; set; }
    private List<EnemyView> _enemyViews => injectionBinder.GetInstance<LevelsPipelineModel>().CurrentLevel.LevelWaves.CurrentWave.EnemiesOnScene;
    private float _waveHold => injectionBinder.GetInstance<LevelsPipelineModel>().CurrentLevel.LevelWaves.CurrentWave.Config.WaveHold;
    public override void Execute()
    {
        Dictionary<Vector3, EnemyView> _tempList = new Dictionary<Vector3, EnemyView>();
        for (int i=0; i < _enemyViews.Count; i++)
        {
            var _percentage = (TowerModel.ShootDelay + _enemyViews[i].EnemyTween.Elapsed() + (_waveHold * (i+1))) 
                / _enemyViews[i].EnemyTween.Duration();

            if (_percentage < 1)
            {
                var getPoint = _enemyViews[i].EnemyTween.PathGetPoint(_percentage);
                _tempList.Add(getPoint, _enemyViews[i]);
            }
        }
        injectionBinder.GetInstance<ReadyToShootSignal>().Dispatch(_tempList, TowerModel);
 //       Debug.Log("PrepareForShootCommand");
    }
}
