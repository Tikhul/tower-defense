using context.level;
using strange.extensions.mediation.impl;
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
    private void ChangeEnemyHealthHandler(int damage, EnemyView view)
    {
        Debug.Log("ChangeEnemyHealthHandler");
        ChangeEnemyHealthSignal.Dispatch(damage, view);
    }
}
 