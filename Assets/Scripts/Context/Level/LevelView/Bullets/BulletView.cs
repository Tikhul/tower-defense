using System;
using System.Linq;
using DG.Tweening;
using UnityEngine;

public class BulletView : BaseView
{
    public int BulletDamage { get; set; }
    public event Action<int, EnemyView> OnBulletHit = delegate { };
    public event Action OnTowerDataRenew = delegate { };
    
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag.Equals("Enemy"))
        {
            OnBulletHit?.Invoke(BulletDamage, other.gameObject.GetComponent<EnemyView>());
            gameObject.SetActive(false);
        }
    }

    private void AfterShoot(TowerModel towerModel, TowerView towerView)
    {
        if (towerView.EnemyViews.Any())
        {
            Destroy(gameObject);
        }
        else
        {
            RenewTowerData();
        }
    }

    private void RenewTowerData()
    {
        OnTowerDataRenew?.Invoke();
    }
    
    public void ShootBullet(TowerView towerView, TowerModel towerModel, Vector3 enemyTransform)
    {
        BulletDamage = towerModel.Damage;
        if (towerView.ShootsNumber == towerModel.BulletsNumber)
        {
            transform.DOLocalMoveZ(
                    Vector3.Distance(transform.position, enemyTransform) * 100 + 10,
                    towerView.BulletTime)
                .OnComplete(RenewTowerData);
        }
        else if(towerView.ShootsNumber < towerModel.BulletsNumber)
        {
            transform.DOLocalMoveZ(
                    Vector3.Distance(transform.position, enemyTransform) * 100 + 10, 
                    towerView.BulletTime)
                .OnComplete(() => AfterShoot(towerModel, towerView));
        }
    }
}
