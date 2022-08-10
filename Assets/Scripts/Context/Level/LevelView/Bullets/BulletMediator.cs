using context.level;
using strange.extensions.mediation.impl;
using UnityEngine;

public class BulletMediator : Mediator
{
    [Inject] public BulletView View { get; set; }
    [Inject] public ChangeEnemyHealthSignal ChangeEnemyHealthSignal { get; set; }
    [Inject] public PrepareForShootSignal PrepareForShootSignal { get; set; }
    public override void OnRegister()
    {
        View.OnBulletHit += ChangeEnemyHealthHandler;
        View.OnBulletShot += PrepareAnotherShootHandler;
    }
    public override void OnRemove()
    {
        View.OnBulletHit -= ChangeEnemyHealthHandler;
        View.OnBulletShot -= PrepareAnotherShootHandler;
    }
    private void ChangeEnemyHealthHandler(int damage, EnemyView view)
    {
        Debug.Log("ChangeEnemyHealthHandler");
        ChangeEnemyHealthSignal.Dispatch(damage, view);
    }
    private void PrepareAnotherShootHandler(TowerModel towerModel, TowerView towerView)
    {
        PrepareForShootSignal.Dispatch(towerModel, towerView);
        Destroy(View);
    }
}
 