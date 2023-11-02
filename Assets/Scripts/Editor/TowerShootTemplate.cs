using UnityEngine;

public abstract class TowerShootTemplate : BaseView
{
    public void TowerShoot(TowerView view, TowerModel tower, Vector3 enemyTransform)
    {
        LaunchShooting();
        TurnTower(view, tower, enemyTransform);
    }

    protected abstract void LaunchShooting();
    protected abstract void TurnTower(TowerView view, TowerModel tower, Vector3 enemyTransform);
}
