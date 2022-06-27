using strange.extensions.mediation.impl;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UpgradeMenuMediator : Mediator
{
    [Inject] public UpgradeMenuView View { get; set; }
    [Inject] public UpgradeMenuCreatedSignal UpgradeMenuCreatedSignal { get; set; }
    [Inject] public HideMenuSignal HideMenuSignal { get; set; }

    public override void OnRegister()
    {
        UpgradeMenuCreatedSignal.AddListener(SetUpUpgradeButtonsHandler);
        HideMenuSignal.AddListener(ClearMenuHandler);
    }
    public override void OnRemove()
    {
        UpgradeMenuCreatedSignal.RemoveListener(SetUpUpgradeButtonsHandler);
        HideMenuSignal.RemoveListener(ClearMenuHandler);
    }
    private void SetUpUpgradeButtonsHandler(List<UpgradeModel> _list)
    {
        View.SetUpUpgradeButtons(_list);
        View.Show();
    }

    private void ClearMenuHandler()
    {
        View.Hide();
        View.ClearMenu();
    }
}
