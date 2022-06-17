using strange.extensions.mediation.impl;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoardMediator : Mediator
{
    [Inject] public BoardView View { get; set; }
    [Inject] public DrawBoardSignal DrawBoardSignal { get; set; }

    public override void OnRegister()
    {
        DrawBoardSignal.Dispatch(View.BoardParent);
    }
}
