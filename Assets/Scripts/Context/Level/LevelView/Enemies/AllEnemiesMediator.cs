using strange.extensions.mediation.impl;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AllEnemiesMediator : Mediator
{
    [Inject] public AllEnemiesView View { get; set; }
}
