using context.ui;
using strange.extensions.injector.impl;
using strange.extensions.mediation.impl;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelRestartMediator : Mediator
{
    [Inject] public LevelRestartView View { get; set; }
    [Inject] public ShowRestartPanelSignal ShowRestartPanelSignal { get; set; }
    [Inject] public RestartLevelChosenSignal RestartLevelChosenSignal { get; set; }
    [Inject] public NextLevelChosenSignal NextLevelChosenSignal { get; set; }
    public override void OnRegister()
    {
        ShowRestartPanelSignal.AddListener(ShowRestartPanel);
        View.OnRestartClick += RestartLevelHandler;
        View.OnNextClick += StartNextLevelHandler;
    }

    public override void OnRemove()
    {
        ShowRestartPanelSignal.RemoveListener(ShowRestartPanel);
        View.OnRestartClick -= RestartLevelHandler;
        View.OnNextClick -= StartNextLevelHandler;
    }

    private void ShowRestartPanel()
    {
        View.Show();
    }

    private void RestartLevelHandler()
    {
        RestartLevelChosenSignal.Dispatch();
        View.Hide();
    }

    private void StartNextLevelHandler()
    {
        NextLevelChosenSignal.Dispatch();
        View.Hide();
    }
}
