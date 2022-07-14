using strange.extensions.mediation.impl;
using context.ui;
using context.level;
using System.Collections.Generic;
using System.Collections;
using UnityEngine;

public class BoardMediator : Mediator
{
    [Inject] public BoardView View { get; set; }
    [Inject] public GameModel GameModel { get; set; }
    [Inject] public LevelsPipelineModel LevelsPipelineModel { get; set; }
    [Inject] public DrawBoardSignal DrawBoardSignal { get; set; }
    [Inject] public ShowRestartPanelSignal ShowRestartPanelSignal { get; set; }
    [Inject] public PipelineEndedSignal PipelineEndedSignal { get; set; }
    [Inject] public RestartLevelChosenSignal RestartLevelChosenSignal { get; set; }
    [Inject] public NextLevelChosenSignal NextLevelChosenSignal { get; set; }
    [Inject] public OnEnemyWayDefinedSignal OnEnemyWayDefinedSignal { get; set; }
    [Inject] public ActivateEnemySignal ActivateEnemySignal { get; set; }

    public override void OnRegister()
    {
        DrawBoardSignal.Dispatch(View.BoardParent);
        OnEnemyWayDefinedSignal.AddListener(DrawEnemiesHandler);
        RestartLevelChosenSignal.AddListener(ShowPanelHandler);
        NextLevelChosenSignal.AddListener(ShowPanelHandler);
        ShowRestartPanelSignal.AddListener(HidePanelHandler);
        PipelineEndedSignal.AddListener(HidePanelHandler);
    }

    public override void OnRemove()
    {
        RestartLevelChosenSignal.RemoveListener(ShowPanelHandler);
        NextLevelChosenSignal.RemoveListener(ShowPanelHandler);
        ShowRestartPanelSignal.RemoveListener(HidePanelHandler);
        PipelineEndedSignal.RemoveListener(HidePanelHandler);
        OnEnemyWayDefinedSignal.RemoveListener(DrawEnemiesHandler);
    }
    private void ShowPanelHandler()
    {
        View.Show();
    }

    private void HidePanelHandler()
    {
        View.Hide();
    }
    private void DrawEnemiesHandler()
    {
        Debug.Log("DrawEnemiesHandler");
        List<EnemyModel> _tempList = new List<EnemyModel>();

        _tempList.AddRange(LevelsPipelineModel.CurrentLevel.LevelWaves.CurrentWave.WaveEnemies);

        for (int i=0; i < _tempList.Count; i++)
        {
            Debug.Log(i);
            StartCoroutine(ActivateEnemy(_tempList[i]));
        }
    }

    private IEnumerator ActivateEnemy(EnemyModel enemy)
    {
        ActivateEnemySignal.Dispatch(LevelsPipelineModel.CurrentLevel.EnemyWay.Config.Indexes[0], enemy);
        yield return new WaitForSeconds(1.5f);
        Debug.Log("ActivateEnemyCoroutine");
    }
}
