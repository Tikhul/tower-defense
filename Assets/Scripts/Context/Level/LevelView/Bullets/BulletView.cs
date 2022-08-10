using System;
using System.Linq;
using DG.Tweening;
using UnityEditor;
using UnityEngine;

public class BulletView : BaseView
{
    public int BulletDamage { get; set; }
    public event Action<int, EnemyView> OnBulletHit = delegate { };
    public event Action<TowerModel, TowerView> OnBulletShot = delegate { };
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag.Equals("Enemy"))
        {
            Debug.Log("OnBulletHit");
            OnBulletHit?.Invoke(BulletDamage, other.gameObject.GetComponent<EnemyView>());
            gameObject.SetActive(false);
        }
    }

    public void ShootBullet(TowerView towerView, TowerModel towerModel, Vector3 enemyTransform)
    {
        if (towerView.ShootsNumber == towerModel.BulletsNumber)
        {
            transform.DOLocalMoveZ(
                    Vector3.Distance(transform.position, enemyTransform) * 100,
                    towerView.BulletTime)
                .OnComplete(() => towerView.RenewData());
        }
        else if(towerView.ShootsNumber < towerModel.BulletsNumber)
        {
            transform.DOLocalMoveZ(
                    Vector3.Distance(transform.position, enemyTransform) * 100, 
                    towerView.BulletTime)
                .OnComplete(() => AfterShoot(towerModel, towerView));
        }
    }
    private void AfterShoot(TowerModel towerModel, TowerView towerView)
    {
        if (towerView.EnemyViews.Any())
        {
            OnBulletShot?.Invoke(towerModel, towerView);
        }
        else
        {
            towerView.RenewData();
        }
    }
}
