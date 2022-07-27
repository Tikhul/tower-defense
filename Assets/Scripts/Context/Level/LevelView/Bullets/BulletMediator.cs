using context.level;
using strange.extensions.mediation.impl;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletMediator : Mediator
{
    [Inject] public BulletView View { get; set; }
    [Inject] public ChangeEnemyHealthSignal ChangeEnemyHealthSignal { get; set; }
    public override void OnRegister()
    {
        ChangeEnemyHealthSignal.AddListener(ChangeEnemyHealthHandler);
    }
    public override void OnRemove()
    {
        ChangeEnemyHealthSignal.RemoveListener(ChangeEnemyHealthHandler);
    }
    private void ChangeEnemyHealthHandler(int _damage)
    {
        ChangeEnemyHealthSignal.Dispatch(_damage);
    }
}
 