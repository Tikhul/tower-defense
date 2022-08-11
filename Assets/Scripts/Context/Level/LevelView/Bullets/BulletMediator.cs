using context.level;
using strange.extensions.mediation.impl;
using UnityEngine;

public class BulletMediator : Mediator
{
    [Inject] public BulletView View { get; set; }
    [Inject] public BulletHitEnemySignal BulletHitEnemySignal { get; set; }
    [Inject] public RenewTowerDataSignal RenewTowerDataSignal { get; set; }
        
    public override void OnRegister()
    {
        View.OnBulletHit += ChangeEnemyHealthHandler;
        View.OnTowerDataRenew += RenewTowerDataHandler;
    }
    
    public override void OnRemove()
    {
        View.OnBulletHit -= ChangeEnemyHealthHandler;
        View.OnTowerDataRenew -= RenewTowerDataHandler;
    }
    
    private void ChangeEnemyHealthHandler(int damage, EnemyView view)
    {
        Debug.Log("ChangeEnemyHealthHandler");
        BulletHitEnemySignal.Dispatch(damage, view);
    }
    
    private void RenewTowerDataHandler()
    {
        RenewTowerDataSignal.Dispatch();
        Destroy(View.gameObject);
    }
}
 