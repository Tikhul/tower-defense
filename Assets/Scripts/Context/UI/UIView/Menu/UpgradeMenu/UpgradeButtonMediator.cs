using strange.extensions.mediation.impl;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UpgradeButtonMediator : Mediator
{
    [Inject] public UpgradeButtonView View { get; set; }
}
