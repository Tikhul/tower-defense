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
        View.OnBulletHit += ChangeEnemyHealthHandler;
    }
    public override void OnRemove()
    {
        View.OnBulletHit -= ChangeEnemyHealthHandler;
    }
    private void ChangeEnemyHealthHandler(int _damage, EnemyView _view)
    {
        Debug.Log("ChangeEnemyHealthHandler");
        ChangeEnemyHealthSignal.Dispatch(_damage, _view);
    }
}
 