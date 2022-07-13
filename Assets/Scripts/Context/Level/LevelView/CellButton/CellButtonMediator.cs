using strange.extensions.mediation.impl;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CellButtonMediator : Mediator
{
    [Inject] public CellButtonView View { get; set; }
    // TODO: перенести все из BoardMediator
}
