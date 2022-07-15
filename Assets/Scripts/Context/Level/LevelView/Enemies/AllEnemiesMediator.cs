using context.level;
using strange.extensions.mediation.impl;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AllEnemiesMediator : Mediator
{
    [Inject] public AllEnemiesView View { get; set; }
    [Inject] public OnEnemyWayDefinedSignal OnEnemyWayDefinedSignal { get; set; }
    [Inject] public ActivateEnemySignal ActivateEnemySignal { get; set; }
    [Inject] public LevelsPipelineModel LevelsPipelineModel { get; set; }
    public override void OnRegister()
    {
        OnEnemyWayDefinedSignal.AddListener(DrawEnemiesHandler);
    }
    public override void OnRemove()
    {
        OnEnemyWayDefinedSignal.RemoveListener(DrawEnemiesHandler);
    }
    private void DrawEnemiesHandler()
    {
        Debug.Log("DrawEnemiesHandler");
        List<EnemyModel> _tempList = new List<EnemyModel>();

        _tempList.AddRange(LevelsPipelineModel.CurrentLevel.LevelWaves.CurrentWave.WaveEnemies);

        for (int i = 0; i < _tempList.Count; i++)
        {
            StartCoroutine(ActivateEnemy(_tempList[i]));
        }
    }

    private IEnumerator ActivateEnemy(EnemyModel enemy)
    {
        View.ActivateEnemy(LevelsPipelineModel.CurrentLevel.EnemyWay.Config.Indexes[0], enemy);
        yield return new WaitForSeconds(1.5f);
        Debug.Log("ActivateEnemyCoroutine");
    }
}
