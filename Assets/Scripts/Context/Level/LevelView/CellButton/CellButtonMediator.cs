using strange.extensions.mediation.impl;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CellButtonMediator : Mediator
{
    [Inject] public CellButtonView View { get; set; }
    [Inject] public ShowMenuSignal ShowMenuSignal { get; set; }

    public override void OnRegister()
    {
        View.OnCellButtonClick += OnCellButtonClickHandler;
    }

    public override void OnRemove()
    {
        View.OnCellButtonClick -= OnCellButtonClickHandler;
    }
    private void OnCellButtonClickHandler(CellState state)
    {
        ShowMenuSignal.Dispatch(state);
    }
}
