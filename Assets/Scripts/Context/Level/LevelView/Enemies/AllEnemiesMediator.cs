using context.level;
using context.ui;
using strange.extensions.mediation.impl;
using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;

public class AllEnemiesMediator : Mediator
{
    [Inject] public AllEnemiesView View { get; set; }
    [Inject] public LevelsPipelineModel LevelsPipelineModel { get; set; }
    [Inject] public ActivateWaveSignal ActivateWaveSignal { get; set; }
    [Inject] public NextLevelChosenSignal NextLevelChosenSignal { get; set; }
    [Inject] public RestartLevelChosenSignal RestartLevelChosenSignal { get; set; }
    public override void OnRegister()
    {
        DrawEnemiesHandler();
        ActivateWaveSignal.AddListener(DrawEnemiesHandler);
        NextLevelChosenSignal.AddListener(DrawEnemiesHandler);
        RestartLevelChosenSignal.AddListener(DrawEnemiesHandler);
        LevelsPipelineModel.CurrentLevel.LevelWaves.CurrentWave.OnWaveBegin += DrawEnemiesHandler;
    }
    public override void OnRemove()
    {
        LevelsPipelineModel.CurrentLevel.LevelWaves.CurrentWave.OnWaveBegin -= DrawEnemiesHandler;
    }
    private void DrawEnemiesHandler()
    {
        if (LevelsPipelineModel.CurrentLevel.EnemyWay.Config.Indexes[0].Equals(
            View.CellButtonView.CellInt.ToString() + View.CellButtonView.CellChar.ToString()))
        {
            List<EnemyModel> _tempList = new List<EnemyModel>();
            _tempList.AddRange(LevelsPipelineModel.CurrentLevel.LevelWaves.CurrentWave.WaveEnemies);
            StartCoroutine(ActivateEnemy(_tempList));
            ActivateWaveSignal.RemoveListener(DrawEnemiesHandler);
        }
    }
    private IEnumerator ActivateEnemy(List<EnemyModel> _enemies)
    {
        for (int i=0; i < _enemies.Count; i++)
        {
            if (i == 0)
            {
                if(i != _enemies.Count - 1)
                {
                    yield return new WaitForSeconds(1f);
                    View.ActivateEnemy(_enemies[i], false);
                }
                else
                {
                    yield return new WaitForSeconds(1f);
                    View.ActivateEnemy(_enemies[i], true);
                }
                Debug.Log("ActivateEnemy - first");
            }
            else
            {
                if (i != _enemies.Count - 1)
                {
                    yield return new WaitForSeconds(2f);
                    View.ActivateEnemy(_enemies[i], false);
                }
                else
                {
                    yield return new WaitForSeconds(2f);
                    View.ActivateEnemy(_enemies[i], true);
                }
                Debug.Log("ActivateEnemy");
            }
        }
    }
}
