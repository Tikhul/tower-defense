using strange.extensions.mediation.impl;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CellMediator : Mediator
{
    [Inject] public CellView View { get; set; }
}
