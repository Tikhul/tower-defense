using UnityEngine;

public interface ITowerShoot
{
    void LaunchShooting();
    void TurnTower(TowerView view, TowerModel tower, Vector3 enemyTransform);
}