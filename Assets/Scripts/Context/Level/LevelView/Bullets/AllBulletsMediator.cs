using strange.extensions.mediation.impl;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AllBulletsMediator : Mediator
{
    [Inject] public AllBulletsView View { get; set; }
}
