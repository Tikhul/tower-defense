using context.ui;
using strange.extensions.context.api;
using strange.extensions.mediation.impl;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerMenuMediator : Mediator
{
    [Inject] public TowerMenuView View { get; set; }
    [Inject] public TowerMenuCreatedSignal TowerMenuCreatedSignal { get; set; }
    [Inject] public HideSubMenuSignal HideSubMenuSignal { get; set; }

    public override void OnRegister()
    {
        TowerMenuCreatedSignal.AddListener(SetUpTowerButtonsHandler);
        HideSubMenuSignal.AddListener(ClearMenuHandler);
    }
    public override void OnRemove()
    {
        TowerMenuCreatedSignal.RemoveListener(SetUpTowerButtonsHandler);
        HideSubMenuSignal.RemoveListener(ClearMenuHandler);
    }

    private void SetUpTowerButtonsHandler(List<TowerView> list)
    {
        View.SetUpTowerButtons(list);
        View.Show();
    }
    private void ClearMenuHandler()
    {
        View.Hide();
        View.ClearMenu();
    }
}
