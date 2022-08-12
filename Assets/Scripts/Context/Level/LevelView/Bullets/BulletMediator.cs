using context.level;
using strange.extensions.mediation.impl;

public class BulletMediator : Mediator
{
    [Inject] public BulletView View { get; set; }
    [Inject] public BulletHitEnemySignal BulletHitEnemySignal { get; set; }

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
        BulletHitEnemySignal.Dispatch(damage, view);
    }
}
 