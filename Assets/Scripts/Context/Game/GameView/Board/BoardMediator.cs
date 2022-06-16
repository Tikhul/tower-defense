using strange.extensions.mediation.impl;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoardMediator : Mediator
{
    [Inject] public BoardView View { get; set; }
    [Inject] public BoardCreatedSignal BoardCreatedSignal { get; set; }
    [Inject] public BoardLibraryModel BoardLibraryModel { get; set; }

    public override void OnRegister()
    {
        View.OnBoardViewActivated += CreateBoardHandler;
    }

    private void CreateBoardHandler()
    {
        
    }
}
