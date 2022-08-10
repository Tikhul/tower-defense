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

    public override void OnRegister()
    {
        DrawEnemiesHandler();
        ActivateWaveSignal.AddListener(DrawEnemiesHandler);
        View.OnEnemyCreated += FillEnemyDictionaryHandler;
    }
    public override void OnRemove()
    {
        ActivateWaveSignal.RemoveListener(DrawEnemiesHandler);
        View.OnEnemyCreated -= FillEnemyDictionaryHandler;
    }
    private void DrawEnemiesHandler()
    {
        if (LevelsPipelineModel.CurrentLevel.EnemyWay.Config.Indices[0].Equals(
            View.CellView.CellInt.ToString() + View.CellView.CellChar.ToString()))
        {
            List<EnemyModel> tempList = new List<EnemyModel>();
            tempList.AddRange(LevelsPipelineModel.CurrentLevel.LevelWaves.CurrentWave.WaveEnemies);
            StartCoroutine(ActivateEnemy(tempList));  
        }
    }
    private IEnumerator ActivateEnemy(List<EnemyModel> enemies)
    {
        for (int i=0; i < enemies.Count; i++)
        {
            if (i == 0)
            {
                yield return new WaitForSeconds(LevelsPipelineModel.CurrentLevel.LevelWaves.
                    CurrentWave.Config.WaveHold);
                View.ActivateEnemy(enemies[i]);
                UnBlockShootButtonSignal.Dispatch();
            }
            else
            {
                yield return new WaitForSeconds(LevelsPipelineModel.CurrentLevel.LevelWaves.
                    CurrentWave.Config.WaveHold);
                View.ActivateEnemy(enemies[i]);
            }
        }
    }

    private void FillEnemyDictionaryHandler(EnemyView view, EnemyModel model)
    {
        LevelsPipelineModel.CurrentLevel.LevelWaves.CurrentWave.EnemyData.Add(view, model);
    }
}
