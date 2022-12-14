using context.level;
using context.ui;
using strange.extensions.mediation.impl;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AllEnemiesMediator : Mediator
{
    [Inject] public AllEnemiesView View { get; set; }
    [Inject] public LevelsPipelineModel LevelsPipelineModel { get; set; }
    [Inject] public ActivateWaveSignal ActivateWaveSignal { get; set; }
    [Inject] public UnBlockShootButtonSignal UnBlockShootButtonSignal { get; set; }
    [Inject] public ChangeEnemyHealthSignal ChangeEnemyHealthSignal { get; set; }
    public override void OnRegister()
    {
        DrawEnemiesHandler();
        ActivateWaveSignal.AddListener(DrawEnemiesHandler);
        ChangeEnemyHealthSignal.AddListener(DamageEnemyHandler);
    }
    public override void OnRemove()
    {
        ActivateWaveSignal.RemoveListener(DrawEnemiesHandler);
        ChangeEnemyHealthSignal.RemoveListener(DamageEnemyHandler);
    }
    private void DrawEnemiesHandler()
    {
        if (LevelsPipelineModel.CurrentLevel.EnemyWay.Config.Indexes[0].Equals(
            View.CellButtonView.CellInt.ToString() + View.CellButtonView.CellChar.ToString()))
        {
            List<EnemyModel> _tempList = new List<EnemyModel>();
            _tempList.AddRange(LevelsPipelineModel.CurrentLevel.LevelWaves.CurrentWave.WaveEnemies);
            StartCoroutine(ActivateEnemy(_tempList));  
        }
    }
    private IEnumerator ActivateEnemy(List<EnemyModel> _enemies)
    {
        for (int i=0; i < _enemies.Count; i++)
        {
            if (i == 0)
            {
                yield return new WaitForSeconds(LevelsPipelineModel.CurrentLevel.LevelWaves.CurrentWave.Config.WaveHold);
                View.ActivateEnemy(_enemies[i]);
                UnBlockShootButtonSignal.Dispatch();
            }
            else
            {
                yield return new WaitForSeconds(LevelsPipelineModel.CurrentLevel.LevelWaves.CurrentWave.Config.WaveHold);
                View.ActivateEnemy(_enemies[i]);
            }
        }
    }
    private void DamageEnemyHandler(int _damage, EnemyView _view)
    {
        _view.Damage(_damage);
    }
}
