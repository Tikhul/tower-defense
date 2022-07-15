using context.level;
using strange.extensions.mediation.impl;
using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;

public class AllEnemiesMediator : Mediator
{
    [Inject] public AllEnemiesView View { get; set; }
    [Inject] public OnEnemyWayDefinedSignal OnEnemyWayDefinedSignal { get; set; }
    [Inject] public ActivateEnemySignal ActivateEnemySignal { get; set; }
    [Inject] public LevelsPipelineModel LevelsPipelineModel { get; set; }
    [Inject] public EnemyActivatedSignal EnemyActivatedSignal { get; set; }
    [Inject] public PipelineStartSignal PipelineStartSignal { get; set; }
    public override void OnRegister()
    {
        DrawEnemiesHandler();
        OnEnemyWayDefinedSignal.AddListener(DrawEnemiesHandler);
    }
    public override void OnRemove()
    {
        OnEnemyWayDefinedSignal.RemoveListener(DrawEnemiesHandler);
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
        for (int i=0; i< _enemies.Count; i++)
        {
            if (i == 0)
            { 
                View.ActivateEnemy(_enemies[i]);
                EnemyActivatedSignal.Dispatch();
                Debug.Log("ActivateEnemy - first");
            }
            else
            {
                yield return new WaitForSeconds(2f);
                View.ActivateEnemy(_enemies[i]);
                EnemyActivatedSignal.Dispatch();
                Debug.Log("ActivateEnemy");
            }
        }
    }
}
